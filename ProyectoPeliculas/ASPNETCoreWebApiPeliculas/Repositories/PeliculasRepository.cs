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

        public async Task<bool> CrearPelicula(Pelicula pelicula) {
            bool response = false;
            try {
                await AppDbContext.peliculas.AddAsync(pelicula);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<List<Pelicula>> GetPeliculas() {
            return await AppDbContext.peliculas.ToListAsync();
        }

        public async Task<bool> ActualizarPelicula(Pelicula pelicula) {
            bool response = false;
            try {
                Pelicula movieToUpdate = await AppDbContext.peliculas.Where(p =>
                    p.id_pelicula == pelicula.id_pelicula).FirstOrDefaultAsync();
                movieToUpdate.nombre_pelicula = pelicula.nombre_pelicula;
                movieToUpdate.fecha_estreno = pelicula.fecha_estreno;
                movieToUpdate.presupuesto = pelicula.presupuesto;
                movieToUpdate.recaudacion = pelicula.recaudacion;
                movieToUpdate.sinopsis = pelicula.sinopsis;
                movieToUpdate.calificacion = pelicula.calificacion;
                movieToUpdate.directores = pelicula.directores;
                movieToUpdate.generos = pelicula.generos;
                movieToUpdate.idiomas = pelicula.idiomas;
                movieToUpdate.productoras = pelicula.productoras;
                movieToUpdate.id_detalle = pelicula.id_detalle;
                AppDbContext.peliculas.Update(movieToUpdate); 
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<bool> EliminarPelicula(int id_pelicula) {
            bool response = false;
            try {
                Pelicula movieToDelete = await AppDbContext.peliculas.Where(p =>
                    p.id_pelicula == id_pelicula).FirstOrDefaultAsync();
                List<Descarga> descargas = await AppDbContext.descargas.Where(d => 
                    d.id_pelicula == movieToDelete.id_pelicula).ToListAsync();
                foreach(Descarga descarga in descargas) {
                    await this.descargas.EliminarDescarga(descarga.id_descarga);
                }
                AppDbContext.peliculas.Remove(movieToDelete);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }
    }
}