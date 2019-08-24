using System;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreWebApiPeliculas.Services;
using ASPNETCoreWebApiPeliculas.Models;
using System.Threading.Tasks;

namespace ASPNETCoreWebApiPeliculas.Controllers
{
    [ApiController] [Route("Api/[controller]/[action]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioContext usuarioContext;
        private readonly IUserService userService;

        public UsuariosController(UsuarioContext usuarioContext, IUserService userService) {
            this.usuarioContext = usuarioContext; this.userService = userService;
        }

        //POST: https://localhost:5001/Api/Usuarios/GetTokenAuthentication
        [HttpPost] [ActionName("GetTokenAuthentication")]
        public Task<string> TokenAuthenticationAsync([FromBody] Usuario user) {
            string userNameEmail = "", token = "";
            if(!String.IsNullOrEmpty(user.correo_usuario))
                userNameEmail = user.correo_usuario;
            else
                userNameEmail = user.nombre_usuario;
            token = userService.GetTokenAuthentication(userNameEmail, user.password_usuario);
            if (token == null)
                return Task.FromResult("Usuario o contraseña incorrectos.");
            return Task.FromResult(token);
        }

        //GET: https://localhost:5001/Api/Usuarios/GetUsuario/?id_usuario=[value]
        [HttpGet] [ActionName("GetUsuario")]
        public Task<Usuario> GetUserAsync(int id_usuario) {
            return usuarioContext.usuarios.FindAsync(id_usuario);
        }
    }
}