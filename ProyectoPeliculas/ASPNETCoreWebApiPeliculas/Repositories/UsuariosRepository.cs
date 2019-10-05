using System;
using System.Net;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ASPNETCoreWebApiPeliculas.Models;
using ASPNETCoreWebApiPeliculas.Services;

namespace ASPNETCoreWebApiPeliculas 
{
    public class UsuariosRepository : IUsuarios
    {
        private readonly ApplicationDbContext AppDbContext;
        private readonly IUserService userService;
        public UsuariosRepository(ApplicationDbContext AppDbContext, IUserService userService) {
            this.AppDbContext = AppDbContext; this.userService = userService;
        }
        
        public async Task<Object []> CrearUsuario(Usuario user) {
            Object [] response = new Object [2];
            try {
                string originalPassword = user.password_usuario; user.tipo_usuario = 2;
                user.password_usuario = userService.EncryptPassword(originalPassword);
                await AppDbContext.usuarios.AddAsync(user); await AppDbContext.SaveChangesAsync();
                Usuario userToAuthenticate = await AppDbContext.usuarios.Where(u =>
                    u.nombre_usuario.Equals(user.nombre_usuario)).FirstOrDefaultAsync();                
                Usuario userToGetTokenRequest = new Usuario() {
                    nombre_usuario = user.nombre_usuario,
                    password_usuario = originalPassword
                };
                Object [] requestResponse = await SolicitudToken(userToGetTokenRequest);
                if(requestResponse[0] != null && (bool) requestResponse[0] == true) {
                    UsuarioSolicitud ultimaSolicitud = await AppDbContext.usuariosSolicitudes.Where(
                    us => us.id_usuario == userToAuthenticate.id_usuario && us.id_solicitud == 2
                    && us.status_solicitud == 0).LastOrDefaultAsync();
                    ultimaSolicitud.status_solicitud = 1; ultimaSolicitud.aprobacion_solicitud = DateTime.Now;
                    AppDbContext.usuariosSolicitudes.Update(ultimaSolicitud); await AppDbContext.SaveChangesAsync();
                    await userService.GetTokenAuthentication(userToAuthenticate.nombre_usuario, originalPassword);
                    response[0] = true;
                }
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> GetUsuario(string username_email) {
            Object [] response = new Object [2];
            try {
                response[0] = await AppDbContext.usuarios.Where(u => u.nombre_usuario.Equals(username_email)
                    || u.correo_usuario.Equals(username_email)).FirstOrDefaultAsync();
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> GetUsuarios() {
            Object [] response = new Object [2];
            try {
                response[0] = await AppDbContext.usuarios.ToListAsync();
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> ActualizarUsuario(Usuario user) {
            Object [] response = new Object [2];
            try {
                Usuario userToUpdate = await AppDbContext.usuarios.Where(u =>
                u.id_usuario == user.id_usuario).FirstOrDefaultAsync();
                userToUpdate.nombre_usuario = user.nombre_usuario;
                userToUpdate.correo_usuario = user.correo_usuario;
                if(!userToUpdate.password_usuario.Equals(user.password_usuario)) {
                    userToUpdate.password_usuario = userService.EncryptPassword(user.password_usuario);
                }
                userToUpdate.tipo_usuario = user.tipo_usuario;
                AppDbContext.usuarios.Update(userToUpdate); 
                await AppDbContext.SaveChangesAsync();
                response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> EliminarUsuario(int id_usuario) {
            Object [] response = new Object [2];
            try {
                Usuario userToDelete = await AppDbContext.usuarios.Where(u =>
                u.id_usuario == id_usuario).FirstOrDefaultAsync();
                List<UsuarioSolicitud> solicitudesToDelete = await AppDbContext.usuariosSolicitudes.Where(
                    us => us.id_usuario == userToDelete.id_usuario).ToListAsync();
                foreach(UsuarioSolicitud solicitud in solicitudesToDelete)
                    AppDbContext.usuariosSolicitudes.Remove(solicitud);
                List<Token> tokensToDelete = await AppDbContext.tokens.Where(
                    t => t.id_usuario == userToDelete.id_usuario).ToListAsync();
                foreach(Token token in tokensToDelete)
                    AppDbContext.tokens.Remove(token);
                AppDbContext.usuarios.Remove(userToDelete);
                await AppDbContext.SaveChangesAsync();
                response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;  
        }

        public async Task<Object []> GetDecryptedPassword(int id_usuario) {
            Object [] response = new Object [2];
            try {
                Usuario user = await AppDbContext.usuarios.FindAsync(id_usuario);
                response[0] = userService.DecryptPassword(user.password_usuario);
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> SolicitudToken(Usuario user) {
            Object [] response = new Object [2];
            string userNameEmail = "", decryptedPassword = "";
            userNameEmail = GetUserNameEmail(user.nombre_usuario, user.correo_usuario);
            Usuario userToUpdate = await AppDbContext.usuarios.Where(u =>
                u.nombre_usuario.Equals(userNameEmail) || u.correo_usuario.Equals(userNameEmail)
            ).FirstOrDefaultAsync();
            if(userToUpdate == null) { response[0] = false; return response; }            
            decryptedPassword = userService.DecryptPassword(userToUpdate.password_usuario);
            if(!user.password_usuario.Equals(decryptedPassword)) { response[0] = false; return response; }
            UsuarioSolicitud ultimaSolicitud = await AppDbContext.usuariosSolicitudes.Where(
                us => us.id_usuario == userToUpdate.id_usuario && us.id_solicitud == 2
                && (us.status_solicitud == 0 || us.status_solicitud == 1)).LastOrDefaultAsync();
            if(ultimaSolicitud != null) { response[0] = false; return response; }
            try {
                UsuarioSolicitud solicitudActual = new UsuarioSolicitud() {
                    id_usuario = userToUpdate.id_usuario,
                    id_solicitud = 2, status_solicitud = 0,
                    emision_solicitud = DateTime.Now
                };
                await AppDbContext.usuariosSolicitudes.AddAsync(solicitudActual);
                await AppDbContext.SaveChangesAsync(); response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> GetTokenAuthentication(Usuario user) {
            Object [] response = new Object [2];
            try {
                string userNameEmail = GetUserNameEmail(user.nombre_usuario, user.correo_usuario);
                response[0] = await userService.GetTokenAuthentication(userNameEmail, user.password_usuario);
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> GetForgottenPassword(string user_email) {
            Object [] response = new Object [2];
            string admin_email, adminPass, userPass, subject, message;
            try {
                Usuario userToRecover = await AppDbContext.usuarios.Where(u =>
                u.correo_usuario == user_email).FirstOrDefaultAsync();
                if(userToRecover == null) { response[0] = false; return response; }
                userPass = userService.DecryptPassword(userToRecover.password_usuario);
                Usuario userAdmin = await AppDbContext.usuarios.Where(u =>
                u.nombre_usuario == "admin").FirstOrDefaultAsync();
                if(userAdmin == null) { response[0] = false; return response; }
                admin_email = userAdmin.correo_usuario;
                adminPass = userService.DecryptPassword(userAdmin.password_usuario);
                UsuarioSolicitud solicitudActual = new UsuarioSolicitud() {
                    id_usuario = userToRecover.id_usuario,
                    id_solicitud = 1,
                    status_solicitud = 2,
                    emision_solicitud = DateTime.Now,
                    aprobacion_solicitud = DateTime.Now
                };
                subject = "Recuperación de Contraseña de Películas";
                message = "<p><strong>Tu contraseña es: </strong>"+userPass+".</p>";
                SendEmail(admin_email, adminPass, user_email, subject, message);
                await AppDbContext.usuariosSolicitudes.AddAsync(solicitudActual);
                await AppDbContext.SaveChangesAsync(); response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public void SendEmail(string from_email, string pass_email,
            string to_email, string subject, string message) {
            try {
                string messageBodyHtml = message;
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(from_email);
                mailMessage.To.Add(new MailAddress(to_email));
                mailMessage.Subject = subject;
                mailMessage.Body = messageBodyHtml;
                mailMessage.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new NetworkCredential(
                    from_email, pass_email);
                smtpClient.Send(mailMessage);
            } catch(Exception e) {
                Console.WriteLine("Excepction Message: "+e.Message);
            }
        }

        public string GetUserNameEmail(string nombre, string correo) {
            return !String.IsNullOrEmpty(nombre) ? nombre: correo;
        }
    }
}