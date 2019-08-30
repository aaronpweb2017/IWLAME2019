using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPNETCoreWebApiPeliculas.Services;
using ASPNETCoreWebApiPeliculas.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ASPNETCoreWebApiPeliculas.Controllers
{
    [ApiController] [Route("Api/[controller]/[action]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext AppDbContext;
        //private readonly IUserService userService;

        public UsuariosController(ApplicationDbContext AppDbContext) {
            this.AppDbContext = AppDbContext; //this.userService = userService;
        }

        //GET: https://localhost:5001/Api/Usuarios/GetUsuario/?userName=[value]
        [HttpGet] [ActionName("GetUsuario")]
        public Task<Usuario> GetUserAsync(string userName) {
            return AppDbContext.usuarios.Where(usuario => 
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
            Usuario userToUpdate = AppDbContext.usuarios.
            Where(usuario => usuario.correo_usuario == userNameEmail
            || usuario.nombre_usuario == userNameEmail).FirstOrDefaultAsync().Result;
            UsuarioSolicitud ultimaSolicitud = AppDbContext.usuariosSolicitudes.Where(
                us => us.id_usuario == userToUpdate.id_usuario  && us.id_solicitud == 2
                && us.status_solicitud == 0).LastOrDefaultAsync().Result;
            if(ultimaSolicitud != null ) {
                Console.WriteLine("DEJA DE ESTAR HACIENDO PETICIONES...");
                return Task.FromResult(response);
            }
            try {
                Solicitud solicitud = AppDbContext.solicitudes.FindAsync(2).Result;
                UsuarioSolicitud solicitudActual = new UsuarioSolicitud() {
                    id_usuario = userToUpdate.id_usuario,
                    usuario = userToUpdate,
                    id_solicitud = 2,
                    solicitud = solicitud,
                    status_solicitud = 0,
                    emision_solicitud = DateTime.Now
                };
                AppDbContext.usuariosSolicitudes.AddAsync(solicitudActual);
                AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception message: "+exception.Message);
            }
            return Task.FromResult(response);
        }

        //GET: https://localhost:5001/Api/Usuarios/GetSolicitudes/?userName=[value]
        // [HttpGet] [ActionName("GetSolicitud")]
        // public Task<List<UsuarioSolicitud>> GetRequestsAsync(string userName) {
        //     List<UsuarioSolicitud> usuario_solicitudes = AppDbContext.usuarios.
        //         Where(usuario => usuario.nombre_usuario == userName).
        //         FirstOrDefaultAsync().Result.usuario_solicitudes;
        //     return Task.FromResult(usuario_solicitudes);
        // }

        //POST: https://localhost:5001/Api/Usuarios/CrearSolicitud
        // [HttpPost] [ActionName("CrearSolicitud")]
        // public Task<bool> CreateRequestAsync([FromBody] UsuarioSolicitud solicitud) {
        //     bool response = false;
        //     try {
        //         EFCoreContext.AddAsync(solicitud);
        //         EFCoreContext.SaveChangesAsync();
        //         response = true;
        //     }
        //     catch(Exception exception) {
        //         Console.WriteLine("Exception message: "+exception.Message);
        //     }
        //     return Task.FromResult(response);
        // }

        //POST: https://localhost:5001/Api/Usuarios/CrearUsuario
        [HttpPost] [ActionName("CrearUsuario")]
        public Task<bool> CreateUserAsync([FromBody] Usuario user) {
            bool response = false;
            try {
                AppDbContext.usuarios.AddAsync(user);
                AppDbContext.SaveChangesAsync();
                response = true;
            }
            catch(Exception exception) {
                Console.WriteLine(":"+exception.Message);
            }
            return Task.FromResult(response);
        }

        //POST: https://localhost:5001/Api/Usuarios/GetTokenAuthentication
        // [HttpPost] [ActionName("GetTokenAuthentication")]
        // public Task<string> TokenAuthenticationAsync([FromBody] Usuario user) {
        //     string userNameEmail = "", response = "";
        //     if(!String.IsNullOrEmpty(user.correo_usuario))
        //         userNameEmail = user.correo_usuario;
        //     else 
        //         userNameEmail = user.nombre_usuario;
        //     response = userService.GetTokenAuthentication(userNameEmail, user.password_usuario);
        //     return Task.FromResult(response);
        // }
    }
}