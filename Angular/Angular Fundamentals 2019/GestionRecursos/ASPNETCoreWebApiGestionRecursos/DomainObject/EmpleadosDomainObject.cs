using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiORAGestionRecursos.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebApiORAGestionRecursos 
{
    public class EmpleadosDomainObject
    {
        EmpleadosDAO empleadosDAO;
        public EmpleadosDomainObject(EmpleadoContext empleadoContext) {
            empleadosDAO = new EmpleadosDAO(empleadoContext);
        }

        public async Task<List<Empleado>> GetEmpleados() {    
            return await empleadosDAO.GetEmpleados();
        }

        public async Task<Empleado> GetEmpleado(int id_empleado) {    
            return await empleadosDAO.GetEmpleado(id_empleado);
        }
        
        public async Task<bool> CrearEmpleado(Empleado empleado) {    
            return await empleadosDAO.CrearEmpleado(empleado);
        }

        public async Task<bool> ActualizarEmpleado(int id_empleado, Empleado empleado) {
            return await empleadosDAO.ActualizarEmpleado(id_empleado, empleado);
        }

        public async Task<bool> BorrarEmpleado(int id_empleado) {
            return await empleadosDAO.BorrarEmpleado(id_empleado);
        }
    }
}