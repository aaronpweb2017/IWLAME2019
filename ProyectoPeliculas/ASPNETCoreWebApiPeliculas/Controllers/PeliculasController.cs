using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreWebApiPeliculas.Models;
//using Microsoft.AspNetCore.Authorization;

namespace ASPNETCoreWebApiPeliculas.Controllers
{
    [ApiController] [Route("Api/[controller]/[action]")] //[Authorize]
    public class PeliculasController : ControllerBase
    {
        private readonly IPeliculas peliculas;
        
        public PeliculasController(IPeliculas peliculas) {
            this.peliculas = peliculas;
        }

        //POST: https://localhost:5001/Api/Peliculas/CrearPelicula
        [HttpPost] [ActionName("CrearPelicula")]
        public async Task<Object []> CreateMovieAsync([FromBody] Pelicula pelicula) {
            return await peliculas.CrearPelicula(pelicula);
        }

        //GET: https://localhost:5001/Api/Peliculas/GetPeliculas
        [HttpGet] [ActionName("GetPeliculas")]
        public async Task<Object []> GetMoviesAsync() {
            return await peliculas.GetPeliculas();
        }

        //PUT: https://localhost:5001/Api/Peliculas/ActualizarPelicula
        [HttpPut] [ActionName("ActualizarPelicula")]
        public async Task<Object []> UpdateMovieAsync([FromBody] Pelicula pelicula) {
            return await peliculas.ActualizarPelicula(pelicula);
        }

        //DELETE: https://localhost:5001/Api/Peliculas/EliminarPelicula?id_pelicula=[value]
        [HttpDelete] [ActionName("EliminarPelicula")]
        public async Task<Object []> DeleteMovieAsync(int id_pelicula) {
            return await peliculas.EliminarPelicula(id_pelicula);
        }
    }
}