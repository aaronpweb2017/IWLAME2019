using System.Threading.Tasks;
using ASPNETCoreWebApiPeliculas.Models;

namespace ASPNETCoreWebApiPeliculas 
{
    public interface IUsuarios
    {
        Task<bool> CrearUsuario(Usuario user);
        Task<Usuario> GetUsuario(string username_email);
        Task<bool> SolicitudToken(Usuario user);
        Task<string> GetTokenAuthentication(Usuario user);
        Task<bool> GetForgottenPassword(string correo_usuario);
    } 
}