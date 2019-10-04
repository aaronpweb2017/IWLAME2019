using System;
using System.Threading.Tasks;
using ASPNETCoreWebApiPeliculas.Models;

namespace ASPNETCoreWebApiPeliculas 
{
    public class SolicitudesRepository : ISolicitudes
    {
        private readonly ApplicationDbContext AppDbContext;
        public SolicitudesRepository(ApplicationDbContext AppDbContext) {
            this.AppDbContext = AppDbContext;
        }

        public async Task<Object []> AprobarSolicitud(int id_usuario_solicitud) {
            Object [] response = new Object [2];
            try {
                UsuarioSolicitud solicitud = await AppDbContext.usuariosSolicitudes.FindAsync(id_usuario_solicitud);
                if(solicitud.status_solicitud != 0) { response[0] = false; return response; }
                solicitud.status_solicitud = 1; solicitud.aprobacion_solicitud = DateTime.Now;
                AppDbContext.usuariosSolicitudes.Update(solicitud);
                await AppDbContext.SaveChangesAsync();
                response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }
    }
}