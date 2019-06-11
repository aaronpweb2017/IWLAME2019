using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiORAGestionRecursos.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebApiORAGestionRecursos 
{
    public class EmpleadosManager : IEmpleadosManager
    {
        EmpleadosDomainObject empleadosDO;
        public EmpleadosManager(EmpleadoContext empleadoContext) {
            empleadosDO = new EmpleadosDomainObject(empleadoContext);
        }

        public async Task<List<Empleado>> GetEmpleados() {    
            return await empleadosDO.GetEmpleados();
        }

        public async Task<Empleado> GetEmpleado(int id_empleado) {    
            return await empleadosDO.GetEmpleado(id_empleado);
        }
        
        public async Task<bool> CrearEmpleado(Empleado empleado) {    
            return await empleadosDO.CrearEmpleado(empleado);
        }

        public async Task<bool> ActualizarEmpleado(int id_empleado, Empleado empleado) {
            return await empleadosDO.ActualizarEmpleado(id_empleado, empleado);
        }

        public async Task<bool> BorrarEmpleado(int id_empleado) {
            return await empleadosDO.BorrarEmpleado(id_empleado);
        }
    }
}