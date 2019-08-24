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
        public Task<string> TokenAuthentication([FromBody] Usuario user) {
            string token = userService.GetTokenAuthentication(user.id_usuario, user.password_usuario);
            if (token == null)
                return Task.FromResult("Id Incorrect.");
            return Task.FromResult(token);
        }

        //GET: https://localhost:5001/Api/Usuarios/GetUsuario/?id_usuario=[value]
        [HttpGet] [ActionName("GetUsuario")]
        public Task<Usuario> GetUserAsync(int id_usuario) {
            return usuarioContext.usuarios.FindAsync(id_usuario);
        }
    }
}