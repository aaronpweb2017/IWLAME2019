using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPNETCoreWebApiPeliculas.Services;
using ASPNETCoreWebApiPeliculas.Models;
using System.Threading.Tasks;

namespace ASPNETCoreWebApiPeliculas.Controllers
{
    [ApiController] [Route("Api/[controller]/[action]")] //[Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioContext usuarioContext;
        private readonly UsuarioSolicitudContext solicitudContext;
        private readonly IUserService userService;

        public UsuariosController(UsuarioContext usuarioContext,
            UsuarioSolicitudContext solicitudContext, IUserService userService) {
            this.usuarioContext = usuarioContext;
            this.solicitudContext = solicitudContext;
            this.userService = userService;
        }

        //GET: https://localhost:5001/Api/Usuarios/GetUsuario/?id_usuario=[value]
        [HttpGet] [ActionName("GetUsuario")]
        public Task<Usuario> GetUserAsync(string userName) {
            return usuarioContext.usuarios.Where(usuario => 
            usuario.nombre_usuario == userName).FirstOrDefaultAsync();
        }

        //POST: https://localhost:5001/Api/Usuarios/SolicitudToken
        [HttpPost] [ActionName("SolicitudToken")]
        public Task<bool> RequestTokenAsync([FromBody] Usuario user) {
            string userNameEmail = ""; bool response = false;
            if(!String.IsNullOrEmpty(user.correo_usuario))
                userNameEmail = user.correo_usuario;
            else 
                userNameEmail = user.nombre_usuario;
            try {
                Usuario UpdatedUser = usuarioContext.usuarios.
                Where(usuario => usuario.correo_usuario == userNameEmail
                || usuario.nombre_usuario == userNameEmail).FirstOrDefaultAsync().Result;
                UsuarioSolicitud solicitudAnterior = solicitudContext.solicitudes.
                Where(solicitud => solicitud.id_usuario == UpdatedUser.id_usuario
                && solicitud.id_solicitud == 2 && solicitud.status_solicitud == 0).LastOrDefaultAsync().Result;
                if(solicitudAnterior == null) {
                    UsuarioSolicitud solicitudActual = new UsuarioSolicitud() {
                        id_usuario = UpdatedUser.id_usuario,
                        id_solicitud = 2,
                        status_solicitud = 0,
                        fecha_solicitud = DateTime.Parse(DateTime.UtcNow.AddHours(-6).ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                    solicitudContext.AddAsync(solicitudActual);
                    solicitudContext.SaveChangesAsync();   
                }
            }
            catch(Exception exception) {
                Console.WriteLine("Exception message: "+exception.Message);
            }
            return Task.FromResult(response);
        }

        //POST: https://localhost:5001/Api/Usuarios/CrearUsuario
        [HttpPost] [ActionName("CrearUsuario")]
        public Task<bool> CreateUserAsync([FromBody] Usuario user) {
            bool response = false;
            try {
                user.password_usuario = userService.EncryptPassword(user.password_usuario);
                user.token_usuario = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6I"
                    +"jEiLCJuYmYiOjE1NjY2ODcyODIsImV4cCI6MTU2NjY5MDg4MiwiaWF0Ijo"
                    +"xNTY2Njg3MjgyfQ.n9F9Yw7xkv7G705SoLP9iLDTlm70LYfbYCcM4W_kc_g";
                user.tipo_usuario = 2; usuarioContext.AddAsync(user);
                usuarioContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine(":"+exception.Message);
            }
            return Task.FromResult(response);
        }

        //POST: https://localhost:5001/Api/Usuarios/GetTokenAuthentication
        [HttpPost] [ActionName("GetTokenAuthentication")]
        public Task<string> TokenAuthenticationAsync([FromBody] Usuario user) {
            string userNameEmail = "", response = "";
            if(!String.IsNullOrEmpty(user.correo_usuario))
                userNameEmail = user.correo_usuario;
            else 
                userNameEmail = user.nombre_usuario;
            response = userService.GetTokenAuthentication(userNameEmail, user.password_usuario);
            return Task.FromResult(response);
        }
    }
}