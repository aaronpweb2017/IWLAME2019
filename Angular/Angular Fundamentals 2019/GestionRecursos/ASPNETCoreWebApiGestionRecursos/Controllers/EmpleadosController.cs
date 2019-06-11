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
    public class EmpleadosController: ControllerBase
    {
        private readonly IEmpleadosManager empleadosManager;

        public EmpleadosController(IEmpleadosManager empleadosManager) {
            this.empleadosManager = empleadosManager;
        }

        //GET: https://localhost:5001/Api/Empleados/GetEmpleados
        [HttpGet] [ActionName("GetEmpleados")]
        public Task<List<Empleado>> GetEmpleadosAsync() {
            return empleadosManager.GetEmpleados();
        }

        //GET: https://localhost:5001/Api/Empleados/GetEmpleado/?id_empleado=value
        [HttpGet] [ActionName("GetEmpleado")]
        public Task<Empleado> GetEmpleadoAsync(int id_empleado) {
            return empleadosManager.GetEmpleado(id_empleado);
        }

        //POST: https://localhost:5001/Api/Empleados/CrearEmpleado
        [HttpPost] [ActionName("CrearEmpleado")]
        public Task<bool> CrearEmpleadoAsync([FromBody] Empleado empleado) {
            return empleadosManager.CrearEmpleado(empleado);
        }

        //PUT: https://localhost:5001/Api/Empleados/ActualizarEmpleado/?id_empleado=value
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