using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using ASPNETCoreWebApiORAGestionRecursos.Models;

namespace ASPNETCoreWebApiORAGestionRecursos.Controllers
{
    [Route("Api/[controller]/[action]")] [ApiController] [Authorize]
    public class EmpleadosController: ControllerBase
    {
        private readonly IEmpleadosManager empleadosManager;

        public EmpleadosController(IEmpleadosManager empleadosManager) {
            this.empleadosManager = empleadosManager;
        }

        //GET: https://localhost:5001/Api/Empleados/GetNoEmpleados
        [HttpGet] [ActionName("GetNoEmpleados")]
        public Task<int> GetNoEmpleadosAsync() {
            return empleadosManager.GetNoEmpleados();
        }
        
        //GET: https://localhost:5001/Api/Empleados/GetEmpleados
        [HttpGet] [ActionName("GetEmpleados")]
        public Task<List<Empleado>> GetEmpleadosAsync() {
            return empleadosManager.GetEmpleados();
        }

        //GET: https://localhost:5001/Api/Empleados/GetEmpleadosActivos
        [HttpGet] [ActionName("GetEmpleadosActivos")]
        public Task<List<Empleado>> GetEmpleadosActivosAsync() {
            return empleadosManager.GetEmpleadosActivos();
        }

        //GET: https://localhost:5001/Api/Empleados/GetAsignadosPaginacion/?no_pagina=[value]
        [HttpGet] [ActionName("GetAsignadosPaginacion")]
        public Task<int[]> GetAsignadosPaginacionAsync(int no_pagina) {
            return empleadosManager.GetAsignadosPaginacion(no_pagina);
        }

        //GET: https://localhost:5001/Api/Empleados/GetEmpleadosPaginacion/?no_pagina=[value]
        [HttpGet] [ActionName("GetEmpleadosPaginacion")]
        public Task<List<Empleado>> GetEmpleadosPaginationAsync(int no_pagina) {
            return empleadosManager.GetEmpleadosPaginacion(no_pagina);
        }

        //GET: https://localhost:5001/Api/Empleados/GetEmpleado/?id_empleado=[value]
        [HttpGet] [ActionName("GetEmpleado")]
        public IActionResult GetEmpleadoAsync(int id_empleado) {
            Empleado empleado = empleadosManager.GetEmpleado(id_empleado).Result;
            if (empleado != null) { return Ok(empleado); } return NotFound();
            //return empleadosManager.GetEmpleado(id_empleado);
        }

        //GET: https://localhost:5001/Api/Empleados/GetEmpleadoTrabajando/?id_empleado=[value]
        [HttpGet] [ActionName("GetEmpleadoTrabajando")]
        public Task<bool> GetEmpleadoTrabajandoAsync(int id_empleado) {
            return empleadosManager.GetEmpleadoTrabajando(id_empleado);
        }

        //POST: https://localhost:5001/Api/Empleados/CrearEmpleado
        [HttpPost] [ActionName("CrearEmpleado")]
        public Task<bool> CrearEmpleadoAsync([FromBody] Empleado empleado) {
            return empleadosManager.CrearEmpleado(empleado);
        }

        //PUT: https://localhost:5001/Api/Empleados/ActualizarEmpleado/?id_empleado=[value]
        [HttpPut] [ActionName("ActualizarEmpleado")]
        public Task<bool> ActualizarEmpleadoAsync(int id_empleado, [FromBody] Empleado empleado) {
            return empleadosManager.ActualizarEmpleado(id_empleado, empleado); 
        }

        //DELETE: https://localhost:5001/Api/Empleados/BorrarEmpleado/?id_empleado=value
        [HttpDelete] [ActionName("BorrarEmpleado")]
        public Task<bool> BorrarEmpleadoAsync(int id_empleado) {
            return empleadosManager.BorrarEmpleado(id_empleado);
        }
    }
}