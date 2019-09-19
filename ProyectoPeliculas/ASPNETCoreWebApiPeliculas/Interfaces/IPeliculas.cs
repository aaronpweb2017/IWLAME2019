using System.Threading.Tasks;
using System.Collections.Generic;
using ASPNETCoreWebApiPeliculas.Models;

namespace ASPNETCoreWebApiPeliculas 
{
    public interface IPeliculas
    {
        Task<bool> CrearPelicula(Pelicula pelicula);
        Task<List<Pelicula>> GetPeliculas();
        Task<bool> ActualizarPelicula(Pelicula pelicula);
        Task<bool> EliminarPelicula(int id_pelicula);
    }
}