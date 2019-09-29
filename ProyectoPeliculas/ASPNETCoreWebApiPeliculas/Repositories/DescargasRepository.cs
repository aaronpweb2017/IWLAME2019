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
                    await EliminarDescarga(descarga.id_descarga);
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
                    await EliminarDescarga(descarga.id_descarga);
                }
                AppDbContext.servidores.Remove(serverToDelete);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;  
        }

        public async Task<bool> CrearDescarga(Descarga descarga) {
            bool response = false;
            try {
                await AppDbContext.descargas.AddAsync(descarga);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<List<Descarga>> GetDescargas() {
            return await AppDbContext.descargas.ToListAsync();
        }

        public async Task<bool> ActualizarDescarga(Descarga descarga) {
            bool response = false;
            try {
                Descarga downloadToUpdate = await AppDbContext.descargas.Where(d =>
                    d.id_descarga == descarga.id_descarga).FirstOrDefaultAsync();
                downloadToUpdate.password_descarga = descarga.password_descarga;
                downloadToUpdate.id_tipo_archivo = descarga.id_tipo_archivo;
                downloadToUpdate.id_servidor = descarga.id_servidor;
                downloadToUpdate.id_pelicula = descarga.id_pelicula;
                AppDbContext.descargas.Update(downloadToUpdate); 
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<bool> EliminarDescarga(int id_descarga) {
            bool response = false;
            try {
                Descarga downloadToDelete = await AppDbContext.descargas.Where(d =>
                    d.id_descarga == id_descarga).FirstOrDefaultAsync();
                List<Enlace> enlaces = await AppDbContext.enlaces.Where(e =>
                    e.id_descarga == downloadToDelete.id_descarga).ToListAsync();
                foreach(Enlace enlace in enlaces)
                    AppDbContext.enlaces.Remove(enlace);
                AppDbContext.descargas.Remove(downloadToDelete);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;  
        }

        public async Task<bool> CrearEnlace(Enlace enlace) {
            bool response = false;
            try {
                await AppDbContext.enlaces.AddAsync(enlace);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<List<Enlace>> GetEnlacesDescarga(int id_descarga) {
            return await AppDbContext.enlaces.Where(e => e.id_descarga == id_descarga).ToListAsync();
        }

        public async Task<bool> ActualizarEnlace(Enlace enlace) {
            bool response = false;
            try {
                Enlace linkToUpdate = await AppDbContext.enlaces.Where(e =>
                    e.id_enlace == enlace.id_enlace).FirstOrDefaultAsync();
                linkToUpdate.valor_enlace = enlace.valor_enlace;
                linkToUpdate.status_enlace = enlace.status_enlace;
                linkToUpdate.id_descarga = enlace.id_descarga;
                AppDbContext.enlaces.Update(linkToUpdate); 
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<Object []> EliminarEnlace(int id_enlace) {
            Object [] response = new Object [2]; response[0] = false;
            try {
                Enlace linkToDelete = await AppDbContext.enlaces.Where(e =>
                    e.id_enlace == id_enlace).FirstOrDefaultAsync();
                AppDbContext.enlaces.Remove(linkToDelete);
                await AppDbContext.SaveChangesAsync(); response[0] = true;
            }
            catch(Exception exception) {
                if(exception.InnerException != null) {
                    response[1] = exception.InnerException.Message;
                    return response;
                }
                response[1] = exception.Message;
            }
            return response;
        }
    }
}