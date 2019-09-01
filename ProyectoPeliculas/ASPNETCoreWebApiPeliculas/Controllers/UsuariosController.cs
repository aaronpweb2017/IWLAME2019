using Microsoft.AspNetCore.Mvc;
using ASPNETCoreWebApiPeliculas.Services;
using ASPNETCoreWebApiPeliculas.Models;
using System.Threading.Tasks;

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