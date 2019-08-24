using System;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using ASPNETCoreWebApiPeliculas.Helpers;
using ASPNETCoreWebApiPeliculas.Models;
using System.Security.Cryptography;
using System.Security.Principal;

namespace ASPNETCoreWebApiPeliculas.Services
{
    public interface IUserService {
        string GetTokenAuthentication(int id_usuario, string password_usuario);
    }

    public class UserService : IUserService {

        private readonly AppSettings appSettings;
        private readonly UsuarioContext usuarioContext;

        public UserService(IOptions<AppSettings> appSettings,
        UsuarioContext usuarioContext) {
            this.usuarioContext = usuarioContext;
            this.appSettings = appSettings.Value;
        }

        public string GetTokenAuthentication(int id_usuario, string password_usuario) {
            Usuario user = usuarioContext.usuarios.FindAsync(id_usuario).Result;
            if (user == null || !password_usuario.Equals(DecryptPassword(user.password_usuario))) return null;
            if(ValidateTokenAuthentication(user.token_usuario)) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("EL TOKEN NO HA EXPIRADO...");
                Console.ForegroundColor = ConsoleColor.Green;
                return user.token_usuario;
            }
            else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("EL TOKEN YA EXPIRÓ...");
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("SOLICITANDO NUEVO TOKEN...");
            Console.ForegroundColor = ConsoleColor.Green;
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.id_usuario.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                //Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool ValidateTokenAuthentication(string authToken) {
            try{
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = GetValidationParameters();
                SecurityToken validatedToken;
                IPrincipal principal = tokenHandler.ValidateToken(authToken,
                validationParameters, out validatedToken);
                return true;
            }
            catch(Exception exception) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("exception: "+exception.Message);
                Console.ForegroundColor = ConsoleColor.Green;
                return false;
            }
        }

        public TokenValidationParameters GetValidationParameters() {
            return new TokenValidationParameters() {
                //ValidIssuer = "Sample",
                //ValidAudience = "Sample",
                ValidIssuer = appSettings.Secret,
                ValidAudience = appSettings.Secret,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                LifetimeValidator = LifetimeValidator,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(appSettings.Secret))
            };
        }

        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, 
            SecurityToken token, TokenValidationParameters @params) {
            if (expires != null) {
                return expires > DateTime.UtcNow;
            }
            return false;
        }

        public string EncryptPassword(string password) {
            byte[] data = UTF8Encoding.UTF8.GetBytes(password);
            string source = "Hello World", hash = "";
            using (MD5 md5Hash = MD5.Create()) {
                hash = GetMd5Hash(md5Hash, source);
            }
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()) {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() 
                { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 }) {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    password = Convert.ToBase64String(results, 0, results.Length);
                }
            }
            return password;
        }

        public string DecryptPassword(string password) {
            byte[] data = Convert.FromBase64String(password);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()) {
                string source = "Hello World", hash = "";
                using (MD5 md5Hash = MD5.Create()) {
                    hash = GetMd5Hash(md5Hash, source);
                }
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider()
                { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 }) {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    password = UTF8Encoding.UTF8.GetString(results);
                }
            }
            return password;
        }

        public string GetMd5Hash(MD5 md5Hash, string input) {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));
            return sBuilder.ToString();
        }

        public bool VerifyMd5Hash(MD5 md5Hash, string input, string hash) {
            string hashOfInput = GetMd5Hash(md5Hash, input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (hashOfInput.Equals(hash))
                return true;
            return false;
        }
    }
}