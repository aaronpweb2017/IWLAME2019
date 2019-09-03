using Microsoft.AspNetCore.Mvc;
using ASPNETCoreWebApiPeliculas.Models;
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

        //GET: https://localhost:5001/Api/Solicitudes/GetSolicitudesPaginacion/?no_pagina=[value]
        [HttpGet] [ActionName("GetSolicitudesPaginacion")]
        public async Task<List<UsuarioSolicitud>> GetRequestsPaginationAsync(int no_pagina) {
            return await solicitudes.GetSolicitudesPaginacion(no_pagina);
        }

        //PUT: https://localhost:5001/Api/Solicitudes/AprobarSolicitud/
        [HttpPut] [ActionName("AprobarSolicitud")]
        public async Task<bool> ApproveRequestAsync([FromBody] int id_usuario_solicitud) {
            return await solicitudes.AprobarSolicitud(id_usuario_solicitud);
        }
    }
}