using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace ASPNETCoreWebApiPeliculas.Controllers
{
    [ApiController] [Route("Api/[controller]/[action]")] [Authorize]
    public class VistasController : ControllerBase
    {
        private readonly IVistas vistas;

        public VistasController(IVistas vistas) {
            this.vistas = vistas;
        }

        //GET: https://192.168.1.68:443/Api/Vistas/GetVistaSolicitudes
        [HttpGet] [ActionName("GetVistaSolicitudes")]
        public async Task<Object []> GetRequestsViewAsync() {
            return await vistas.GetVistaSolicitudes();
        }

        //GET: https://192.168.1.68:443/Api/Vistas/GetVistaTokens
        [HttpGet] [ActionName("GetVistaTokens")]
        public async Task<Object []> GetTokensViewAsync() {
            return await vistas.GetVistaTokens();
        }

        //GET: https://192.168.1.68:443/Api/Vistas/GetVistaResoluciones
        [HttpGet] [ActionName("GetVistaResoluciones")]
        public async Task<Object []> GetResolutionsViewAsync() {
            return await vistas.GetVistaResoluciones();
        }
        
        //GET: https://192.168.1.68:443/Api/Vistas/GetVistaDetallesTecnicos
        [HttpGet] [ActionName("GetVistaDetallesTecnicos")]
        public async Task<Object []> GetTechnicalDetailsViewAsync() {
            return await vistas.GetVistaDetallesTecnicos();
        }

        //GET: https://192.168.1.68:443/Api/Vistas/GetVistaDetalleTecnicoPelicula/?id_pelicula=[value]
        [HttpGet] [ActionName("GetVistaDetalleTecnicoPelicula")]
        public async Task<Object []> GetMovieTechnicalDetailViewAsync(int id_pelicula) {
            return await vistas.GetVistaDetalleTecnicoPelicula(id_pelicula);
        }

        //GET: https://192.168.1.68:443/Api/Vistas/GetVistaDescargas
        [HttpGet] [ActionName("GetVistaDescargas")]
        public async Task<Object []> GetDownloadsViewAsync() {
            return await vistas.GetVistaDescargas();
        }

        //GET: https://192.168.1.68:443/Api/Peliculas/GetVistaDescargasPelicula?id_pelicula=[value]
        [HttpGet] [ActionName("GetVistaDescargasPelicula")]
        public async Task<Object []> GetMovieDownloadsViewAsync(int id_pelicula) {
            return await vistas.GetVistaDescargasPelicula(id_pelicula);
        }
    }
}