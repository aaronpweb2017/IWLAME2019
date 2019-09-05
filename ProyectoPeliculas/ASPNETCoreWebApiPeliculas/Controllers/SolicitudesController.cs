using Microsoft.AspNetCore.Mvc;
using ASPNETCoreWebApiPeliculas.Models;
using ASPNETCoreWebApiPeliculas.Views;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace ASPNETCoreWebApiPeliculas.Controllers
{
    [ApiController] [Route("Api/[controller]/[action]")]
    public class SolicitudesController : ControllerBase
    {
        private readonly ISolicitudes solicitudes;

        public SolicitudesController(ISolicitudes solicitudes) {
            this.solicitudes = solicitudes;
        }


        //GET: https://localhost:5001/Api/Solicitudes/GetNoSolicitudes
        [HttpGet] [ActionName("GetNoSolicitudes")]
        public async Task<int> GetNoRequestsAsync() {
            return await solicitudes.GetNoSolicitudes();
        }

        //PUT: https://localhost:5001/Api/Solicitudes/AprobarSolicitud/
        [HttpPut] [ActionName("AprobarSolicitud")]
        public async Task<bool> ApproveRequestAsync([FromBody] int id_usuario_solicitud) {
            return await solicitudes.AprobarSolicitud(id_usuario_solicitud);
        }

        //GET: https://localhost:5001/Api/Solicitudes/GetSolicitudesViewPaginacion/?no_pagina=[value]
        [HttpGet] [ActionName("GetSolicitudesViewPaginacion")]
        public async Task<List<VSolicitud>> GetRequestsViewPaginationAsync(int no_pagina) {
            return await solicitudes.GetSolicitudesViewPaginacion(no_pagina);
        }
    }
}