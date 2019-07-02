using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ASPNETCoreWebApiORAGestionRecursos.Models;

namespace ASPNETCoreWebApiORAGestionRecursos.Controllers
{
    [Route("Api/[controller]/[action]")] [ApiController]
    public class ProyectosController: ControllerBase
    {
        private readonly IProyectosManager proyectosManager;

        public ProyectosController(IProyectosManager proyectosManager) {
            this.proyectosManager = proyectosManager;
        }

        //GET: https://localhost:5001/Api/Proyectos/GetNoProyectos
        [HttpGet] [ActionName("GetNoProyectos")]
        public Task<int> GetNoProyectosAsync() {
            return proyectosManager.GetNoProyectos();
        }

        //GET: https://localhost:5001/Api/Proyectos/GetProyectos
        [HttpGet] [ActionName("GetProyectos")]
        public Task<List<Proyecto>> GetProyectosAsync() {
            return proyectosManager.GetProyectos();
        }

        //GET: https://localhost:5001/Api/Proyectos/GetProyectosActivos
        [HttpGet] [ActionName("GetProyectosActivos")]
        public Task<List<Proyecto>> GetProyectosActivosAsync() {
            return proyectosManager.GetProyectosActivos();
        }

        //GET: https://localhost:5001/Api/Proyectos/GetProyectosPaginacion/?no_pagina=[value]
        [HttpGet] [ActionName("GetProyectosPaginacion")]
        public Task<List<Proyecto>> GetEmpleadosPaginationAsync(int no_pagina) {
            return proyectosManager.GetProyectosPaginacion(no_pagina);
        }        

        //GET: https://localhost:5001/Api/Proyectos/GetProyecto/?id_proyecto=value
        [HttpGet] [ActionName("GetProyecto")]
        public Task<Proyecto> GetProyectoAsync(int id_proyecto) {
            return proyectosManager.GetProyecto(id_proyecto);
        }

        //GET: https://localhost:5001/Api/Proyectos/GetProyectoAsignado/?id_proyecto=value
        [HttpGet] [ActionName("GetProyectoAsignado")]
        public Task<bool> GetProyectoAsignadoAsync(int id_proyecto) {
            return proyectosManager.GetProyectoAsignado(id_proyecto);
        }

        //POST: https://localhost:5001/Api/Proyectos/CrearProyecto
        [HttpPost] [ActionName("CrearProyecto")]
        public Task<bool> CrearProyectoAsync([FromBody] Proyecto proyecto) {
            return proyectosManager.CrearProyecto(proyecto);
        }

        //PUT: https://localhost:5001/Api/Proyectos/ActualizarProyecto/?id_proyecto=value
        [HttpPut] [ActionName("ActualizarProyecto")]
        public Task<bool> ActualizarProyectoAsync(int id_proyecto, [FromBody] Proyecto proyecto) {
            return proyectosManager.ActualizarProyecto(id_proyecto, proyecto); 
        }

        //DELETE: https://localhost:5001/Api/Proyectos/BorrarProyecto/?id_proyecto=value
        [HttpDelete] [ActionName("BorrarProyecto")]
        public Task<bool> BorrarProyectoAsync(int id_proyecto) {
            return proyectosManager.BorrarProyecto(id_proyecto);
        }
    }
}