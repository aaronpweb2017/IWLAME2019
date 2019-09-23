using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ASPNETCoreWebApiPeliculas.Models;

namespace ASPNETCoreWebApiPeliculas 
{
    public class DescargasRepository : IDescargas
    {
        private readonly ApplicationDbContext AppDbContext;
        public DescargasRepository(ApplicationDbContext AppDbContext) {
            this.AppDbContext = AppDbContext;
        }

        public async Task<bool> CrearTipoArchivo(TipoArchivo tipoArchivo) {
            bool response = false;
            try {
                await AppDbContext.tiposArchivo.AddAsync(tipoArchivo);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<List<TipoArchivo>> GetTiposArchivo() {
            return await AppDbContext.tiposArchivo.ToListAsync();
        }

        public async Task<bool> ActualizarTipoArchivo(TipoArchivo tipoArchivo) {
            bool response = false;
            try {
                TipoArchivo tipoArchivoToUpdate = await AppDbContext.tiposArchivo.Where(ta =>
                    ta.id_tipo_archivo == tipoArchivo.id_tipo_archivo).FirstOrDefaultAsync();
                tipoArchivoToUpdate.nombre_tipo_archivo = tipoArchivo.nombre_tipo_archivo;
                AppDbContext.tiposArchivo.Update(tipoArchivoToUpdate); 
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<bool> EliminarTipoArchivo(int id_tipo_archivo) {
            bool response = false;
            try {
                TipoArchivo tipoArchivoToDelete = await AppDbContext.tiposArchivo.Where(ta =>
                    ta.id_tipo_archivo == id_tipo_archivo).FirstOrDefaultAsync();
                List<Descarga> descargas = await AppDbContext.descargas.Where(d => 
                    d.id_tipo_archivo == tipoArchivoToDelete.id_tipo_archivo).ToListAsync();
                foreach(Descarga descarga in descargas)
                    AppDbContext.descargas.Remove(descarga);
                AppDbContext.tiposArchivo.Remove(tipoArchivoToDelete);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;  
        }




    }
}