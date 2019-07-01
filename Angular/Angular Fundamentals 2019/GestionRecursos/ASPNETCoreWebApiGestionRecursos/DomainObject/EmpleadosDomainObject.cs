using System.Threading.Tasks;
using System.Collections.Generic;
using ASPNETCoreWebApiORAGestionRecursos.Models;

namespace ASPNETCoreWebApiORAGestionRecursos 
{
    public class EmpleadosDomainObject
    {
        EmpleadosDAO empleadosDAO;

        public EmpleadosDomainObject(EmpleadoContext empleadoContext,
        AsignacionContext asignacionContext, ProyectoContext proyectoContext) {
            empleadosDAO = new EmpleadosDAO(empleadoContext,
                asignacionContext, proyectoContext);
        }
        
        public async Task<int> GetNoEmpleados() {    
            return await empleadosDAO.GetNoEmpleados();
        }

        public async Task<List<Empleado>> GetEmpleados() {    
            return await empleadosDAO.GetEmpleados();
        }

        public async Task<List<Empleado>> GetEmpleadosActivos() {    
            return await empleadosDAO.GetEmpleadosActivos();
        }

        public async Task<int[]> GetAsignadosPaginacion(int no_pagina) {    
            return await empleadosDAO.GetAsignadosPaginacion(no_pagina);
        }

        public async Task<List<Empleado>> GetEmpleadosPaginacion(int no_pagina) {
            return await empleadosDAO.GetEmpleadosPaginacion(no_pagina);
        }

        public async Task<Empleado> GetEmpleado(int id_empleado) {
            return await empleadosDAO.GetEmpleado(id_empleado);
        }

        public async Task<bool> GetEmpleadoTrabajando(int id_empleado) {
            return await empleadosDAO.GetEmpleadoTrabajando(id_empleado);
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