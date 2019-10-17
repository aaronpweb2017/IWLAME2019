using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ASPNETCoreWebApiPeliculas.Models;

namespace ASPNETCoreWebApiPeliculas 
{
    public class PeliculasRepository : IPeliculas
    {
        private readonly ApplicationDbContext AppDbContext;
        private readonly IDescargas descargas;

        public PeliculasRepository(ApplicationDbContext AppDbContext, IDescargas descargas) {
            this.AppDbContext = AppDbContext; this.descargas = descargas;
        }

        public async Task<Object []> CrearPelicula(Pelicula pelicula) {
            Object [] response = new Object [2];
            try {
                await AppDbContext.peliculas.AddAsync(pelicula);
                await AppDbContext.SaveChangesAsync();
                response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> GetPelicula(int id_pelicula) {
            Object [] response = new Object [2];
            try {
                Pelicula movie = await AppDbContext.peliculas.Where(p =>
                    p.id_pelicula == id_pelicula).FirstOrDefaultAsync();
                response[0] = movie;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> GetPeliculas() {
            Object [] response = new Object [2];
            try {
                response[0] = await AppDbContext.peliculas.ToListAsync();
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> ActualizarPelicula(Pelicula pelicula) {
            Object [] response = new Object [2];
            try {
                Pelicula movieToUpdate = await AppDbContext.peliculas.Where(p =>
                    p.id_pelicula == pelicula.id_pelicula).FirstOrDefaultAsync();
                movieToUpdate.nombre_pelicula = pelicula.nombre_pelicula;
                //SI CAMBIAS EL NOMBRE DE LA PELÍCULA CAMBIA EL NOMBRE DE SU IMAGEN.
                movieToUpdate.fecha_estreno = pelicula.fecha_estreno;
                movieToUpdate.presupuesto = pelicula.presupuesto;
                movieToUpdate.recaudacion = pelicula.recaudacion;
                movieToUpdate.sinopsis = pelicula.sinopsis;
                movieToUpdate.calificacion = pelicula.calificacion;
                movieToUpdate.directores = pelicula.directores;
                movieToUpdate.generos = pelicula.generos;
                movieToUpdate.urlImagen = pelicula.urlImagen;
                movieToUpdate.id_detalle = pelicula.id_detalle;
                AppDbContext.peliculas.Update(movieToUpdate); 
                await AppDbContext.SaveChangesAsync();
                response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> EliminarPelicula(int id_pelicula) {
            Object [] response = new Object [2];
            try {
                Pelicula movieToDelete = await AppDbContext.peliculas.Where(p =>
                    p.id_pelicula == id_pelicula).FirstOrDefaultAsync();
                List<Descarga> descargas = await AppDbContext.descargas.Where(d => 
                    d.id_pelicula == movieToDelete.id_pelicula).ToListAsync();
                foreach(Descarga descarga in descargas) {
                    await this.descargas.EliminarDescarga(descarga.id_descarga);
                }
                AppDbContext.peliculas.Remove(movieToDelete);
                await AppDbContext.SaveChangesAsync();
                response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> GetNoDescargasPelicula(int id_pelicula) {
            Object [] response = new Object [2];
            try {
                List<Descarga> descargas = await AppDbContext.descargas.Where(d => d.id_pelicula == id_pelicula).ToListAsync();
                response[0] = descargas.Count;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }
    }
}