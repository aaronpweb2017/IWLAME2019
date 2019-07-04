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
        string Authenticate(int id_empleado);
    }

    public class UserService : IUserService {

        private readonly AppSettings _appSettings;
        private readonly EmpleadoContext empleadoContext;

        public UserService(IOptions<AppSettings> appSettings,
        EmpleadoContext empleadoContext) {
            this.empleadoContext = empleadoContext;
            _appSettings = appSettings.Value;
        }

        public string Authenticate(int id_empleado) {
            Empleado user = empleadoContext.empleados.FindAsync(id_empleado).Result;
            if (user == null) return null;
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
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

//https://jasonwatmore.com/post/2018/08/14/aspnet-core-21-jwt
//-authentication-tutorial-with-example-api#users-controller-cs