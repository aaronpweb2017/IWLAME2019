using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using ASPNETCoreWebApiPeliculas.Views;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<List<VSolicitud>> GetRequestsViewAsync() {
            return await vistas.GetVistaSolicitudes();
        }

        //GET: https://localhost:5001/Api/Vistas/GetVistaTokens
        [HttpGet] [ActionName("GetVistaTokens")]
        public async Task<List<VToken>> GetTokensViewAsync() {
            return await vistas.GetVistaTokens();
        }
    }
}