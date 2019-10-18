using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreWebApiPeliculas.Models;
using Microsoft.AspNetCore.Authorization;

namespace ASPNETCoreWebApiPeliculas.Controllers
{
    [ApiController] [Route("Api/[controller]/[action]")] [Authorize]
    public class PeliculasController : ControllerBase
    {
        private readonly IPeliculas peliculas;
        
        public PeliculasController(IPeliculas peliculas) {
            this.peliculas = peliculas;
        }

        //POST: https://192.168.1.68:443/Api/Peliculas/CrearPelicula
        [HttpPost] [ActionName("CrearPelicula")]
        public async Task<Object []> CreateMovieAsync([FromBody] Pelicula pelicula) {
            return await peliculas.CrearPelicula(pelicula);
        }

        //GET: https://192.168.1.68:443/Api/Peliculas/GetPelicula?id_pelicula=[value]
        [HttpGet] [ActionName("GetPelicula")]
        public async Task<Object []> GetMovieAsync(int id_pelicula) {
            return await peliculas.GetPelicula(id_pelicula);
        }

        //GET: https://192.168.1.68:443/Api/Peliculas/GetPeliculas
        [HttpGet] [ActionName("GetPeliculas")]
        public async Task<Object []> GetMoviesAsync() {
            return await peliculas.GetPeliculas();
        }

        //PUT: https://192.168.1.68:443/Api/Peliculas/ActualizarPelicula
        [HttpPut] [ActionName("ActualizarPelicula")]
        public async Task<Object []> UpdateMovieAsync([FromBody] Pelicula pelicula) {
            return await peliculas.ActualizarPelicula(pelicula);
        }

        //DELETE: https://192.168.1.68:443/Api/Peliculas/EliminarPelicula?id_pelicula=[value]
        [HttpDelete] [ActionName("EliminarPelicula")]
        public async Task<Object []> DeleteMovieAsync(int id_pelicula) {
            return await peliculas.EliminarPelicula(id_pelicula);
        }
    }
}