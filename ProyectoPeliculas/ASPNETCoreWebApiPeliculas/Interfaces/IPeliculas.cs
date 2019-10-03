using System;
using System.Threading.Tasks;
using ASPNETCoreWebApiPeliculas.Models;

namespace ASPNETCoreWebApiPeliculas 
{
    public interface IPeliculas
    {
        Task<Object []> CrearPelicula(Pelicula pelicula);
        Task<Object []> GetPeliculas();
        Task<Object []> ActualizarPelicula(Pelicula pelicula);
        Task<Object []> EliminarPelicula(int id_pelicula);
    }
}