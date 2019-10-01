using System;
using System.Threading.Tasks;
using ASPNETCoreWebApiPeliculas.Models;

namespace ASPNETCoreWebApiPeliculas 
{
    public interface IUsuarios
    {
        Task<Object []> CrearUsuario(Usuario user);
        Task<Object []> GetUsuario(string username_email);
        Task<Object []> GetUsuarios();
        Task<Object []> ActualizarUsuario(Usuario user);
        Task<Object []> EliminarUsuario(int id_usuario);
        Task<Object []> GetDecryptedPassword(int id_usuario);
        Task<Object []> SolicitudToken(Usuario user);
        Task<Object []> GetTokenAuthentication(Usuario user);
        Task<Object []> GetForgottenPassword(string correo_usuario);
    } 
}