using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ASPNETCoreWebApiPeliculas.Models;

namespace ASPNETCoreWebApiPeliculas.Controllers
{
    [ApiController] [Route("Api/[controller]/[action]")]
    public class PeliculasController : ControllerBase
    {
        private readonly IPeliculas peliculas;
        
        public PeliculasController(IPeliculas peliculas) {
            this.peliculas = peliculas;
        }

        //POST: https://localhost:5001/Api/Peliculas/CrearPelicula
        [HttpPost] [ActionName("CrearPelicula")]
        public async Task<bool> CreateMovieAsync([FromBody] Pelicula pelicula) {
            return await peliculas.CrearPelicula(pelicula);
        }

        //GET: https://localhost:5001/Api/Peliculas/GetPeliculas
        [HttpGet] [ActionName("GetPeliculas")]
        public async Task<List<Pelicula>> GetMoviesAsync() {
            return await peliculas.GetPeliculas();
        }

        //PUT: https://localhost:5001/Api/Peliculas/ActualizarPelicula
        [HttpPut] [ActionName("ActualizarPelicula")]
        public async Task<bool> UpdateMovieAsync([FromBody] Pelicula pelicula) {
            return await peliculas.ActualizarPelicula(pelicula);
        }

        //DELETE: https://localhost:5001/Api/Peliculas/EliminarPelicula?id_pelicula=[value]
        [HttpPut] [ActionName("EliminarPelicula")]
        public async Task<bool> DeleteMovieAsync(int id_pelicula) {
            return await peliculas.EliminarPelicula(id_pelicula);
        }
    }
}