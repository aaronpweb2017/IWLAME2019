using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPNETCoreWebApiPeliculas.Services;
using ASPNETCoreWebApiPeliculas.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;

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

        //POST: https://localhost:5001/Api/Usuarios/CrearUsuario
        [HttpPost] [ActionName("CrearUsuario")]
        public async Task<bool> CreateUserAsync([FromBody] Usuario user) {
            bool response = false;
            try {
                string originalPassword = user.password_usuario;
                user.password_usuario = userService.EncryptPassword(originalPassword);
                await AppDbContext.usuarios.AddAsync(user); await AppDbContext.SaveChangesAsync();
                response = true;
                if(await TokenRequestAsync(user)) {
                    Usuario userToAuthenticate = await AppDbContext.usuarios.Where(u =>
                    u.nombre_usuario == user.nombre_usuario).FirstOrDefaultAsync();
                    UsuarioSolicitud ultimaSolicitud = await AppDbContext.usuariosSolicitudes.Where(
                    us => us.id_usuario == userToAuthenticate.id_usuario && us.id_solicitud == 2
                    && us.status_solicitud == 0).LastOrDefaultAsync();
                    ultimaSolicitud.status_solicitud = 1; ultimaSolicitud.aprobacion_solicitud = DateTime.Now;
                    AppDbContext.usuariosSolicitudes.Update(ultimaSolicitud); await AppDbContext.SaveChangesAsync();
                    await userService.GetTokenAuthentication(user.nombre_usuario, originalPassword); response = true;
                }
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        //GET: https://localhost:5001/Api/Usuarios/GetUsuario/?username_email=[value]
        [HttpGet] [ActionName("GetUsuario")]
        public async Task<Usuario> GetUserAsync(string username_email) {
            return await AppDbContext.usuarios.Where(u => u.nombre_usuario.Equals(username_email)
                || u.correo_usuario.Equals(username_email)).FirstOrDefaultAsync();
        }

        //POST: https://localhost:5001/Api/Usuarios/SolicitudToken
        [HttpPost] [ActionName("SolicitudToken")]
        public async Task<bool> TokenRequestAsync([FromBody] Usuario user) {
            string userNameEmail = "", decryptedPassword = ""; bool response = false;
            userNameEmail = GetUserNameEmail(user.nombre_usuario, user.correo_usuario);
            Usuario userToUpdate = await AppDbContext.usuarios.Where(u =>
                u.nombre_usuario == userNameEmail || u.correo_usuario == userNameEmail
            ).FirstOrDefaultAsync();
            if(userToUpdate == null) { return response; }
            decryptedPassword = userService.DecryptPassword(userToUpdate.password_usuario);
            if(!user.password_usuario.Equals(decryptedPassword)) { return response; }
            UsuarioSolicitud ultimaSolicitud = await AppDbContext.usuariosSolicitudes.Where(
                us => us.id_usuario == userToUpdate.id_usuario && us.id_solicitud == 2
                && (us.status_solicitud == 0 || us.status_solicitud == 1)).LastOrDefaultAsync();
            if(ultimaSolicitud != null) { return response; }
            try {
                UsuarioSolicitud solicitudActual = new UsuarioSolicitud() {
                    id_usuario = userToUpdate.id_usuario,
                    id_solicitud = 2,
                    status_solicitud = 0,
                    emision_solicitud = DateTime.Now
                };
                await AppDbContext.usuariosSolicitudes.AddAsync(solicitudActual);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        //POST: https://localhost:5001/Api/Usuarios/GetTokenAuthentication
        [HttpPost] [ActionName("GetTokenAuthentication")]
        public async Task<string> GetTokenAuthenticationAsync([FromBody] Usuario user) {
            string userNameEmail = GetUserNameEmail(user.nombre_usuario, user.correo_usuario);
            return await userService.GetTokenAuthentication(userNameEmail, user.password_usuario);
        }

        //GET: https://localhost:5001/Api/Usuarios/GetForgottenPassword/?correo_usuario=[value]
        [HttpGet] [ActionName("GetForgottenPassword")]
        public async Task<bool> GetForgottenPasswordAsync(string correo_usuario) {
            string user_email, decryptedPassword, message; bool response = false;
            Usuario userToRecover = await AppDbContext.usuarios.Where(u =>
                u.correo_usuario == correo_usuario).FirstOrDefaultAsync();
            if(userToRecover == null) {
                Console.WriteLine(" ============================>TU PUTA MADREEEEEEEEEEEEEEEEEEEEEEEEEEE: ");
                return response; }
            try {
                UsuarioSolicitud solicitudActual = new UsuarioSolicitud() {
                    id_usuario = userToRecover.id_usuario,
                    id_solicitud = 1,
                    status_solicitud = 2,
                    emision_solicitud = DateTime.Now,
                    aprobacion_solicitud = DateTime.Now
                };
                user_email = userToRecover.correo_usuario;
                decryptedPassword = userService.DecryptPassword(userToRecover.password_usuario);
                message = "<p><strong>Tu contraseña es: </strong>"+decryptedPassword+".</p>";
                SendEmail(user_email, message);
                await AppDbContext.usuariosSolicitudes.AddAsync(solicitudActual);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public string GetUserNameEmail(string nombre, string correo) {
            if(!String.IsNullOrEmpty(nombre)) {
                return nombre;
            }
            return correo;
        }

        public void SendEmail(string user_email, string message) {
            try {
                string messageBodyHtml = message;
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("aaronecheverria23@gmail.com");
                mailMessage.To.Add(new MailAddress(user_email));
                mailMessage.Subject = "Recuperación de Contraseña de Películas";
                mailMessage.Body = messageBodyHtml;
                mailMessage.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true; //or false
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new NetworkCredential(
                    "aaronecheverria23@gmail.com", "1996lame2019");
                smtpClient.Send(mailMessage);
            } catch(Exception e) {
                Console.WriteLine("Excepction Message: "+e.Message);
            }
        }
    }
}