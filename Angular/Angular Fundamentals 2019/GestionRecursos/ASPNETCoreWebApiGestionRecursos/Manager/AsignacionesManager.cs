using System.Threading.Tasks;
using System.Collections.Generic;
using ASPNETCoreWebApiORAGestionRecursos.Models;

namespace ASPNETCoreWebApiORAGestionRecursos 
{
    public class AsignacionesManager : IAsignacionesManager
    {
        AsignacionesDomainObject asignacionesDO;
        public AsignacionesManager(AsignacionContext asignacionContext,
        ProyectoContext proyectoContext, EmpleadoContext empleadoContext) {
            asignacionesDO = new AsignacionesDomainObject(
            asignacionContext, proyectoContext, empleadoContext);
        }

        public async Task<int> GetNoAsignaciones() {    
            return await asignacionesDO.GetNoAsignaciones();
        }

        public async Task<List<Asignacion>> GetAsignaciones() {
            return await asignacionesDO.GetAsignaciones();
        }

        public async Task<List<Asignacion>> GetAsignacionesPaginacion(int no_pagina) {
            return await asignacionesDO.GetAsignacionesPaginacion(no_pagina);
        }

        public async Task<List<Proyecto>> GetProyectosPaginacion(int no_pagina) {
            return await asignacionesDO.GetProyectosPaginacion(no_pagina);
        }

        public async Task<List<Empleado>> GetEmpleadosPaginacion(int no_pagina) {
            return await asignacionesDO.GetEmpleadosPaginacion(no_pagina);
        }

        public async Task<Asignacion> GetAsignacion(int id_asignacion) {
            return await asignacionesDO.GetAsignacion(id_asignacion);
        }
        
        public async Task<bool> CrearAsignacion(Asignacion asignacion) {
            return await asignacionesDO.CrearAsignacion(asignacion);
        }

        public async Task<bool> ActualizarAsignacion(int id_asignacion, Asignacion asignacion) {
            return await asignacionesDO.ActualizarAsignacion(id_asignacion, asignacion);
        }

        public async Task<bool> BorrarAsignacion(int id_asignacion) {
            return await asignacionesDO.BorrarAsignacion(id_asignacion);
        }
    }
}