using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using ASPNETCoreWebApiPeliculas.Services;
using ASPNETCoreWebApiPeliculas.Models;

namespace ASPNETCoreWebApiPeliculas.Controllers
{
    [ApiController] [Route("Api/[controller]/[action]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarios usuarios;
        private readonly IUserService userService;

        public UsuariosController(IUsuarios usuarios) {
            this.usuarios = usuarios;
        }

        //POST: https://localhost:5001/Api/Usuarios/CrearUsuario
        [HttpPost] [ActionName("CrearUsuario")]
        public async Task<bool> CreateUserAsync([FromBody] Usuario user) {
            return await usuarios.CrearUsuario(user);
        }

        //GET: https://localhost:5001/Api/Usuarios/GetUsuario/?username_email=[value]
        [HttpGet] [ActionName("GetUsuario")]
        public async Task<Usuario> GetUserAsync(string username_email) {
            return await usuarios.GetUsuario(username_email);
        }

        //GET: https://localhost:5001/Api/Usuarios/GetUsuarios
        [HttpGet] [ActionName("GetUsuarios")]
        public async Task<List<Usuario>> GetUsersAsync() {
            return await usuarios.GetUsuarios();
        }

        //PUT: https://localhost:5001/Api/Usuarios/ActualizarUsuario
        [HttpPut] [ActionName("ActualizarUsuario")]
        public async Task<bool> UpdateUser([FromBody] Usuario user) {
            return await usuarios.ActualizarUsuario(user);
        }

        //PUT: https://localhost:5001/Api/Usuarios/EliminarUsuario
        [HttpDelete] [ActionName("EliminarUsuario")]
        public async Task<bool> DeleteUser([FromBody] Usuario user) {
            return await usuarios.EliminarUsuario(user);
        }

        //GET: https://localhost:5001/Api/Usuarios/GetDecryptedPassword/?id_usuario=[value]
        [HttpGet] [ActionName("GetDecryptedPassword")]
        public async Task<string> GetDecryptedPasswordAsync(int id_usuario) {
            return await usuarios.GetDecryptedPassword(id_usuario);
        }

        //POST: https://localhost:5001/Api/Usuarios/SolicitudToken
        [HttpPost] [ActionName("SolicitudToken")]
        public async Task<bool> TokenRequestAsync([FromBody] Usuario user) {
            return await usuarios.SolicitudToken(user);
        }

        //POST: https://localhost:5001/Api/Usuarios/GetTokenAuthentication
        [HttpPost] [ActionName("GetTokenAuthentication")]
        public async Task<string> GetTokenAuthenticationAsync([FromBody] Usuario user) {
            return await usuarios.GetTokenAuthentication(user);
        }

        //GET: https://localhost:5001/Api/Usuarios/GetForgottenPassword/?correo_usuario=[value]
        [HttpGet] [ActionName("GetForgottenPassword")]
        public async Task<bool> GetForgottenPasswordAsync(string correo_usuario) {
            return await usuarios.GetForgottenPassword(correo_usuario);
        }
    }
}