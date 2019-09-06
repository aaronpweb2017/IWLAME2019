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

        public async Task<bool> AprobarSolicitud(int id_usuario_solicitud) {
            bool response = false;
            try {
                UsuarioSolicitud solicitud = await AppDbContext.usuariosSolicitudes.FindAsync(id_usuario_solicitud);
                solicitud.status_solicitud = 1; solicitud.aprobacion_solicitud = DateTime.Now;
                AppDbContext.usuariosSolicitudes.Update(solicitud);
                await AppDbContext.SaveChangesAsync();
                response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }
    }
}