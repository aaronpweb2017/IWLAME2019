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
        private readonly IUserService userService;

        public UsuariosController(ApplicationDbContext AppDbContext, IUserService userService) {
            this.AppDbContext = AppDbContext; this.userService = userService;
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
            try {
                Usuario userToUpdate = AppDbContext.usuarios.
                Where(usuario => usuario.correo_usuario == userNameEmail
                || usuario.nombre_usuario == userNameEmail).FirstOrDefaultAsync().Result;
                UsuarioSolicitud ultimaSolicitud = userToUpdate.usuario_solicitudes.
                Where(us => us.id_solicitud == 2 && us.status_solicitud==0).LastOrDefault();
                if(ultimaSolicitud == null) {
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
                    userToUpdate.usuario_solicitudes.Add(solicitudActual);
                    AppDbContext.usuarios.Update(userToUpdate);
                    AppDbContext.SaveChangesAsync();
                    solicitud.usuario_solicitudes.Add(solicitudActual);
                    AppDbContext.solicitudes.Update(solicitud);
                    AppDbContext.SaveChangesAsync();
                }
            }
            catch(Exception exception) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Exception message: "+exception.Message);
                Console.ForegroundColor = ConsoleColor.Green;
            }
            return Task.FromResult(response);
        }

        //GET: https://localhost:5001/Api/Usuarios/GetSolicitudes/?userName=[value]
        [HttpGet] [ActionName("GetSolicitud")]
        public Task<List<UsuarioSolicitud>> GetRequestsAsync(string userName) {
            List<UsuarioSolicitud> usuario_solicitudes = AppDbContext.usuarios.
                Where(usuario => usuario.nombre_usuario == userName).
                FirstOrDefaultAsync().Result.usuario_solicitudes;
            return Task.FromResult(usuario_solicitudes);
        }

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
        // [HttpPost] [ActionName("CrearUsuario")]
        // public Task<bool> CreateUserAsync([FromBody] Usuario user) {
        //     bool response = false;
        //     try {
        //         user.password_usuario = userService.EncryptPassword(user.password_usuario);
        //         user.token_usuario = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6I"
        //             +"jEiLCJuYmYiOjE1NjY2ODcyODIsImV4cCI6MTU2NjY5MDg4MiwiaWF0Ijo"
        //             +"xNTY2Njg3MjgyfQ.n9F9Yw7xkv7G705SoLP9iLDTlm70LYfbYCcM4W_kc_g";
        //         user.tipo_usuario = 2; EFCoreContext.AddAsync(user);
        //         EFCoreContext.SaveChangesAsync(); response = true;
        //     }
        //     catch(Exception exception) {
        //         Console.WriteLine(":"+exception.Message);
        //     }
        //     return Task.FromResult(response);
        // }

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