using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ASPNETCoreWebApiPeliculas.Controllers
{
    [ApiController] [Route("Api/[controller]/[action]")]
    public class SolicitudesController : ControllerBase
    {
        private readonly ISolicitudes solicitudes;

        public SolicitudesController(ISolicitudes solicitudes) {
            this.solicitudes = solicitudes;
        }

        //PUT: https://localhost:5001/Api/Solicitudes/AprobarSolicitud
        [HttpPut] [ActionName("AprobarSolicitud")]
        public async Task<bool> ApproveRequestAsync([FromBody] int id_usuario_solicitud) {
            return await solicitudes.AprobarSolicitud(id_usuario_solicitud);
        }
    }
}