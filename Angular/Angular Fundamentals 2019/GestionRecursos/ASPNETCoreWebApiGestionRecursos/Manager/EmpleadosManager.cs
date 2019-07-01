using System.Threading.Tasks;
using System.Collections.Generic;
using ASPNETCoreWebApiORAGestionRecursos.Models;

namespace ASPNETCoreWebApiORAGestionRecursos 
{
    public class EmpleadosManager : IEmpleadosManager
    {
        EmpleadosDomainObject empleadosDO;
        public EmpleadosManager(EmpleadoContext empleadoContext,
        AsignacionContext asignacionContext, ProyectoContext proyectoContext) {
            empleadosDO = new EmpleadosDomainObject(empleadoContext,
                asignacionContext, proyectoContext);
        }

        public async Task<int> GetNoEmpleados() {    
            return await empleadosDO.GetNoEmpleados();
        }

        public async Task<List<Empleado>> GetEmpleados() {    
            return await empleadosDO.GetEmpleados();
        }
        
        public async Task<List<Empleado>> GetEmpleadosActivos() {    
            return await empleadosDO.GetEmpleadosActivos();
        }

        public async Task<int[]> GetAsignadosPaginacion(int no_pagina) {    
            return await empleadosDO.GetAsignadosPaginacion(no_pagina);
        }

        public async Task<List<Empleado>> GetEmpleadosPaginacion(int no_pagina) {
            return await empleadosDO.GetEmpleadosPaginacion(no_pagina);
        }

        public async Task<Empleado> GetEmpleado(int id_empleado) {    
            return await empleadosDO.GetEmpleado(id_empleado);
        }

        public async Task<bool> GetEmpleadoTrabajando(int id_empleado) {
            return await empleadosDO.GetEmpleadoTrabajando(id_empleado);
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