using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using ASPNETCoreWebApiPeliculas.Views;

namespace ASPNETCoreWebApiPeliculas.Controllers
{
    [ApiController] [Route("Api/[controller]/[action]")]
    public class VistasController : ControllerBase
    {
        private readonly IVistas vistas;

        public VistasController(IVistas vistas) {
            this.vistas = vistas;
        }

        //GET: https://localhost:5001/Api/Vistas/GetSolicitudesVista
        [HttpGet] [ActionName("GetSolicitudesVista")]
        public async Task<List<VSolicitud>> GetRequestsViewAsync() {
            return await vistas.GetSolicitudesVista();
        }

        //GET: https://localhost:5001/Api/Vistas/GetTokensVista
        [HttpGet] [ActionName("GetTokensVista")]
        public async Task<List<VToken>> GetTokensViewAsync() {
            return await vistas.GetTokensVista();
        }
    }
}