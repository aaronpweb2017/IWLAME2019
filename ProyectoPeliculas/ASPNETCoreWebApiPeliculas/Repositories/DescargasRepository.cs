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
                TipoArchivo fileTypeToUpdate = await AppDbContext.tiposArchivo.Where(ta =>
                    ta.id_tipo_archivo == tipoArchivo.id_tipo_archivo).FirstOrDefaultAsync();
                fileTypeToUpdate.nombre_tipo_archivo = tipoArchivo.nombre_tipo_archivo;
                AppDbContext.tiposArchivo.Update(fileTypeToUpdate); 
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
                TipoArchivo fileTypeToDelete = await AppDbContext.tiposArchivo.Where(ta =>
                    ta.id_tipo_archivo == id_tipo_archivo).FirstOrDefaultAsync();
                List<Descarga> descargas = await AppDbContext.descargas.Where(d => 
                    d.id_tipo_archivo == fileTypeToDelete.id_tipo_archivo).ToListAsync();
                foreach(Descarga descarga in descargas) {
                    List<Enlace> enlaces = await AppDbContext.enlaces.Where(e =>
                        e.id_descarga == descarga.id_descarga).ToListAsync();
                    foreach(Enlace enlace in enlaces)
                        AppDbContext.enlaces.Remove(enlace);
                    AppDbContext.descargas.Remove(descarga);
                }
                AppDbContext.tiposArchivo.Remove(fileTypeToDelete);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;  
        }

        public async Task<bool> CrearServidor(Servidor servidor) {
            bool response = false;
            try {
                await AppDbContext.servidores.AddAsync(servidor);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<List<Servidor>> GetServidores() {
            return await AppDbContext.servidores.ToListAsync();
        }

        public async Task<bool> ActualizarServidor(Servidor servidor) {
            bool response = false;
            try {
                Servidor serverToUpdate = await AppDbContext.servidores.Where(s =>
                    s.id_servidor == servidor.id_servidor).FirstOrDefaultAsync();
                serverToUpdate.nombre_servidor = servidor.nombre_servidor;
                serverToUpdate.sitio_servidor = servidor.sitio_servidor;
                AppDbContext.servidores.Update(serverToUpdate); 
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<bool> EliminarServidor(int id_servidor) {
            bool response = false;
            try {
                Servidor serverToDelete = await AppDbContext.servidores.Where(s =>
                    s.id_servidor == id_servidor).FirstOrDefaultAsync();
                List<Descarga> descargas = await AppDbContext.descargas.Where(d => 
                    d.id_servidor == serverToDelete.id_servidor).ToListAsync();
                foreach(Descarga descarga in descargas) {
                    List<Enlace> enlaces = await AppDbContext.enlaces.Where(e =>
                        e.id_descarga == descarga.id_descarga).ToListAsync();
                    foreach(Enlace enlace in enlaces)
                        AppDbContext.enlaces.Remove(enlace);
                    AppDbContext.descargas.Remove(descarga);
                }
                AppDbContext.servidores.Remove(serverToDelete);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;  
        }
    }
}