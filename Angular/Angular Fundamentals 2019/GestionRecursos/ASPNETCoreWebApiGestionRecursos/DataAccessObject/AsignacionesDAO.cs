using System.Threading.Tasks;
using System.Collections.Generic;
using ASPNETCoreWebApiORAGestionRecursos.Models;

namespace ASPNETCoreWebApiORAGestionRecursos
{
    public class AsignacionesDAO
    {
        AsignacionesRepository asignacionesRepository;
        public AsignacionesDAO(AsignacionContext asignacionContext,
        ProyectoContext proyectoContext, EmpleadoContext empleadoContext) {
            asignacionesRepository = new AsignacionesRepository(
            asignacionContext, proyectoContext, empleadoContext);
        }

        public async Task<int> GetNoAsignaciones() {    
            return await asignacionesRepository.GetNoAsignaciones();
        }

        public async Task<List<Asignacion>> GetAsignaciones() {
            return await asignacionesRepository.GetAsignaciones();
        }

        public async Task<List<Asignacion>> GetAsignacionesPaginacion(int no_pagina) {
            return await asignacionesRepository.GetAsignacionesPaginacion(no_pagina);
        }

        public async Task<List<Proyecto>> GetProyectosPaginacion(int no_pagina) {
            return await asignacionesRepository.GetProyectosPaginacion(no_pagina);
        }

        public async Task<List<Empleado>> GetEmpleadosPaginacion(int no_pagina) {
            return await asignacionesRepository.GetEmpleadosPaginacion(no_pagina);
        }

        public async Task<Asignacion> GetAsignacion(int id_asignacion) {
            return await asignacionesRepository.GetAsignacion(id_asignacion);
        }
        
        public async Task<bool> CrearAsignacion(Asignacion asignacion) {
            return await asignacionesRepository.CrearAsignacion(asignacion);
        }

        public async Task<bool> ActualizarAsignacion(int id_asignacion, Asignacion asignacion) {
            return await asignacionesRepository.ActualizarAsignacion(id_asignacion, asignacion);
        }

        public async Task<bool> BorrarAsignacion(int id_asignacion) {
            return await asignacionesRepository.BorrarAsignacion(id_asignacion);
        }
    }
}