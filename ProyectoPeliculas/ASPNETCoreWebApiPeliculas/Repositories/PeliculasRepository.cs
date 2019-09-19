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

        public PeliculasRepository(ApplicationDbContext AppDbContext) {
            this.AppDbContext = AppDbContext;
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
                movieToUpdate.nombre = pelicula.nombre;
                movieToUpdate.fecha_estreno = pelicula.fecha_estreno;
                movieToUpdate.presupuesto = pelicula.presupuesto;
                movieToUpdate.recaudacion = pelicula.recaudacion;
                movieToUpdate.sinopsis = pelicula.sinopsis;
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