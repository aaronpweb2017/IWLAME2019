using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using ASPNETCoreWebApiPeliculas.Models;

namespace ASPNETCoreWebApiPeliculas 
{
    public interface IUsuarios
    {
        Task<Object []> CrearUsuario(Usuario user);
        Task<Usuario> GetUsuario(string username_email);
        Task<List<Usuario>> GetUsuarios();
        Task<bool> ActualizarUsuario(Usuario user);
        Task<bool> EliminarUsuario(int id_usuario);
        Task<string> GetDecryptedPassword(int id_usuario);
        Task<bool> SolicitudToken(Usuario user);
        Task<string> GetTokenAuthentication(Usuario user);
        Task<bool> GetForgottenPassword(string correo_usuario);
    } 
}