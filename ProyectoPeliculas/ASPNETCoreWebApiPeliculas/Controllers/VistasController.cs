using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreWebApiPeliculas.Views;
//using Microsoft.AspNetCore.Authorization;


namespace ASPNETCoreWebApiPeliculas.Controllers
{
    [ApiController] [Route("Api/[controller]/[action]")] //[Authorize]
    public class VistasController : ControllerBase
    {
        private readonly IVistas vistas;

        public VistasController(IVistas vistas) {
            this.vistas = vistas;
        }

        //GET: https://localhost:5001/Api/Vistas/GetVistaSolicitudes
        [HttpGet] [ActionName("GetVistaSolicitudes")]
        public async Task<Object []> GetRequestsViewAsync() {
            return await vistas.GetVistaSolicitudes();
        }

        //GET: https://localhost:5001/Api/Vistas/GetVistaTokens
        [HttpGet] [ActionName("GetVistaTokens")]
        public async Task<Object []> GetTokensViewAsync() {
            return await vistas.GetVistaTokens();
        }

        //GET: https://localhost:5001/Api/Vistas/GetVistaResoluciones
        [HttpGet] [ActionName("GetVistaResoluciones")]
        public async Task<Object []> GetResolutionsViewAsync() {
            return await vistas.GetVistaResoluciones();
        }
        
        //GET: https://localhost:5001/Api/Vistas/GetVistaDetallesTecnicos
        [HttpGet] [ActionName("GetVistaDetallesTecnicos")]
        public async Task<Object []> GetTechnicalDetailsViewAsync() {
            return await vistas.GetVistaDetallesTecnicos();
        }

        //GET: https://localhost:5001/Api/Vistas/GetVistaDetalleTecnicoPelicula/?id_pelicula=[value]
        [HttpGet] [ActionName("GetVistaDetalleTecnicoPelicula")]
        public async Task<Object []> GetMovieTechnicalDetailViewAsync(int id_pelicula) {
            return await vistas.GetVistaDetalleTecnicoPelicula(id_pelicula);
        }

        //GET: https://localhost:5001/Api/Vistas/GetVistaDescargas
        [HttpGet] [ActionName("GetVistaDescargas")]
        public async Task<Object []> GetDownloadsViewAsync() {
            return await vistas.GetVistaDescargas();
        }
    }
}