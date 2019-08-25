using System;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using ASPNETCoreWebApiPeliculas.Helpers;
using ASPNETCoreWebApiPeliculas.Models;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Logging;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebApiPeliculas.Services
{
    public interface IUserService {
        string GetTokenAuthentication(string userNameEmail, string password_usuario);
        string EncryptPassword(string password);
    }

    public class UserService : IUserService {

        private readonly AppSettings appSettings;
        private readonly UsuarioContext usuarioContext;

        public UserService(IOptions<AppSettings> appSettings,
        UsuarioContext usuarioContext) {
            this.usuarioContext = usuarioContext;
            this.appSettings = appSettings.Value;
        }

        public string GetTokenAuthentication(string userNameEmail, string password_usuario) {
            Usuario user = usuarioContext.usuarios.Where(usuario => usuario.correo_usuario == userNameEmail
                || usuario.nombre_usuario == userNameEmail).FirstOrDefaultAsync().Result; string response;
            if (user == null) { 
               response = "El usuario ingresado no existe."; return response;
            }
            string decryptedPassword = DecryptPassword(user.password_usuario); 
            if (!password_usuario.Equals(decryptedPassword)) { 
                response = "Contraseña incorrecta."; return response; 
            }
            if(ValidateToken(user.token_usuario) != null) { 
                return user.token_usuario;
            }
            if(user.tipo_usuario == 2 && user.aprobacion_usuario == 0) {
                response = "Tu token ha expirado, solicita un "
                + "nuevo token al administrador."; return response;
            }
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.id_usuario.ToString())
                }),
                //Expires = DateTime.UtcNow.AddMinutes(5), //+ 5 extra minutes...
                Expires = DateTime.UtcNow.AddHours(1), //+ 5 extra minutes...
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            Usuario UpdatedUser = usuarioContext.usuarios.FindAsync(user.id_usuario).Result;        
            UpdatedUser.token_usuario = tokenHandler.WriteToken(token);
            UpdatedUser.solicitud_usuario = 0; UpdatedUser.aprobacion_usuario = 0;
            usuarioContext.Update(UpdatedUser); usuarioContext.SaveChangesAsync();
            return tokenHandler.WriteToken(token);
        }

        public ClaimsPrincipal ValidateToken(string jwtToken) {
            try {
                byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);
                IdentityModelEventSource.ShowPII = true;
                SecurityToken validatedToken;
                TokenValidationParameters validationParameters;
                validationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true
                };
                ClaimsPrincipal principal = new JwtSecurityTokenHandler().
                ValidateToken(jwtToken, validationParameters, out validatedToken);
                return principal;
            } catch(Exception exception) { //Token has expired...
                DateTime tokenExpiryDate = GetTokenExpiryDate(jwtToken);
                Console.WriteLine("Token expired date: "+tokenExpiryDate);
                Console.WriteLine("Exception message: "+exception.Message); return null;
            }
        }

        public DateTime GetTokenExpiryDate(string jwtToken) {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.ReadToken(jwtToken) as JwtSecurityToken;
            DateTime tokenExpiryDate = token.ValidTo;
            return tokenExpiryDate.AddHours(-6);
        }

        public string EncryptPassword(string password) {
            byte[] data = UTF8Encoding.UTF8.GetBytes(password);
            string source = appSettings.Hash, hash;
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
                string source = appSettings.Hash, hash;
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