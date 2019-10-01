using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreWebApiPeliculas.Models;

namespace ASPNETCoreWebApiPeliculas.Controllers
{
    [ApiController] [Route("Api/[controller]/[action]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarios usuarios;

        public UsuariosController(IUsuarios usuarios) {
            this.usuarios = usuarios;
        }

        //POST: https://localhost:5001/Api/Usuarios/CrearUsuario
        [HttpPost] [ActionName("CrearUsuario")]
        public async Task<Object []> CreateUserAsync([FromBody] Usuario user) {
            return await usuarios.CrearUsuario(user);
        }

        //GET: https://localhost:5001/Api/Usuarios/GetUsuario/?username_email=[value]
        [HttpGet] [ActionName("GetUsuario")]
        public async Task<Object []> GetUserAsync(string username_email) {
            return await usuarios.GetUsuario(username_email);
        }

        //GET: https://localhost:5001/Api/Usuarios/GetUsuarios
        [HttpGet] [ActionName("GetUsuarios")]
        public async Task<Object []> GetUsersAsync() {
            return await usuarios.GetUsuarios();
        }

        //PUT: https://localhost:5001/Api/Usuarios/ActualizarUsuario
        [HttpPut] [ActionName("ActualizarUsuario")]
        public async Task<Object []> UpdateUserAsync([FromBody] Usuario user) {
            return await usuarios.ActualizarUsuario(user);
        }

        //PUT: https://localhost:5001/Api/Usuarios/EliminarUsuario/?id_usuario=[value]
        [HttpDelete] [ActionName("EliminarUsuario")]
        public async Task<Object []> DeleteUserAsync(int id_usuario) {
            return await usuarios.EliminarUsuario(id_usuario);
        }

        //GET: https://localhost:5001/Api/Usuarios/GetDecryptedPassword/?id_usuario=[value]
        [HttpGet] [ActionName("GetDecryptedPassword")]
        public async Task<Object []> GetDecryptedPasswordAsync(int id_usuario) {
            return await usuarios.GetDecryptedPassword(id_usuario);
        }

        //POST: https://localhost:5001/Api/Usuarios/SolicitudToken
        [HttpPost] [ActionName("SolicitudToken")]
        public async Task<Object []> TokenRequestAsync([FromBody] Usuario user) {
            return await usuarios.SolicitudToken(user);
        }

        //POST: https://localhost:5001/Api/Usuarios/GetTokenAuthentication
        [HttpPost] [ActionName("GetTokenAuthentication")]
        public async Task<Object []> GetTokenAuthenticationAsync([FromBody] Usuario user) {
            return await usuarios.GetTokenAuthentication(user);
        }

        //GET: https://localhost:5001/Api/Usuarios/GetForgottenPassword/?correo_usuario=[value]
        [HttpGet] [ActionName("GetForgottenPassword")]
        public async Task<Object []> GetForgottenPasswordAsync(string correo_usuario) {
            return await usuarios.GetForgottenPassword(correo_usuario);
        }
    }
}