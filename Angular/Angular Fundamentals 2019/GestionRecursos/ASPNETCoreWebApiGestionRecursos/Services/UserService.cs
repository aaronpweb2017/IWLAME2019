using System;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using ASPNETCoreWebApiGestionRecursos.Helpers;
using ASPNETCoreWebApiORAGestionRecursos.Models;

namespace ASPNETCoreWebApiGestionRecursos.Services
{
    public interface IUserService {
        string GetTokenAuthentication(int id_empleado);
    }

    public class UserService : IUserService {

        private readonly AppSettings appSettings;
        private readonly EmpleadoContext empleadoContext;

        public UserService(IOptions<AppSettings> appSettings,
        EmpleadoContext empleadoContext) {
            this.empleadoContext = empleadoContext;
            this.appSettings = appSettings.Value;
        }

        public string GetTokenAuthentication(int id_empleado) {
            Empleado user = empleadoContext.empleados.FindAsync(id_empleado).Result;
            if (user == null) return null;
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.id_empleado.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken  token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}