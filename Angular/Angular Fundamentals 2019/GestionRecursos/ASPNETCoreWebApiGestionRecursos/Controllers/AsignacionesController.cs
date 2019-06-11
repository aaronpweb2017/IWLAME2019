using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreWebApiORAGestionRecursos.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebApiORAGestionRecursos.Controllers
{
    [Route("Api/[controller]/[action]")] [ApiController]
    public class AsignacionesController: ControllerBase
    {
        private readonly IAsignacionesManager asignacionesManager;

        public AsignacionesController(IAsignacionesManager asignacionesManager) {
            this.asignacionesManager = asignacionesManager;
        }

        //GET: https://localhost:5001/Api/Asignaciones/GetAsignaciones
        [HttpGet] [ActionName("GetAsignaciones")]
        public Task<List<Asignacion>> GetAsignacionesAsync() {
            return asignacionesManager.GetAsignaciones();
        }

        //GET: https://localhost:5001/Api/Asignaciones/GetAsignacion/?id_asignacion=value
        [HttpGet] [ActionName("GetAsignacion")]
        public Task<Asignacion> GetAsignacionAsync(int id_asignacion) {
            return asignacionesManager.GetAsignacion(id_asignacion);
        }

        //POST: https://localhost:5001/Api/Asignaciones/CrearAsignacion
        [HttpPost] [ActionName("CrearAsignacion")]
        public Task<bool> CrearAsignacionAsync([FromBody] Asignacion asignacion) {
            return asignacionesManager.CrearAsignacion(asignacion);
        }

        //PUT: https://localhost:5001/Api/Asignaciones/ActualizarAsignacion/?id_asignacion=value
        [HttpPut] [ActionName("ActualizarAsignacion")]
        public Task<bool> ActualizarAsignacionAsync(int id_asignacion, [FromBody] Asignacion asignacion) {
            return asignacionesManager.ActualizarAsignacion(id_asignacion, asignacion); 
        }

        //DELETE: https://localhost:5001/Api/Asignaciones/BorrarAsignacion/?id_asignacion=value
        [HttpDelete] [ActionName("BorrarAsignacion")]
        public Task<bool> BorrarAsignacionAsync(int id_asignacion) {
            return asignacionesManager.BorrarAsignacion(id_asignacion);
        }
    }
}