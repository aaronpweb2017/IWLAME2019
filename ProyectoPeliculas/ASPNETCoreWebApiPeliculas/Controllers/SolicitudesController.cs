using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ASPNETCoreWebApiPeliculas.Controllers
{
    [ApiController] [Route("Api/[controller]/[action]")] [Authorize]
    public class SolicitudesController : ControllerBase
    {
        private readonly ISolicitudes solicitudes;

        public SolicitudesController(ISolicitudes solicitudes) {
            this.solicitudes = solicitudes;
        }

        //PUT: https://189.186.51.66:443/Api/Solicitudes/AprobarSolicitud
        [HttpPut] [ActionName("AprobarSolicitud")]
        public async Task<Object []> ApproveRequestAsync([FromBody] int id_usuario_solicitud) {
            return await solicitudes.AprobarSolicitud(id_usuario_solicitud);
        }
    }
}