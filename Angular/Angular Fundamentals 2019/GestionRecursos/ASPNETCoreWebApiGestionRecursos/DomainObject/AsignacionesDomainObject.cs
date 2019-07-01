using System.Threading.Tasks;
using System.Collections.Generic;
using ASPNETCoreWebApiORAGestionRecursos.Models;

namespace ASPNETCoreWebApiORAGestionRecursos 
{
    public class AsignacionesDomainObject
    {
        AsignacionesDAO asignacionesDAO;
        public AsignacionesDomainObject(AsignacionContext asignacionContext) {
            asignacionesDAO = new AsignacionesDAO(asignacionContext);
        }

        public async Task<int> GetNoAsignaciones() {    
            return await asignacionesDAO.GetNoAsignaciones();
        }

        public async Task<List<Asignacion>> GetAsignaciones() {
            return await asignacionesDAO.GetAsignaciones();
        }

        public async Task<List<Asignacion>> GetAsignacionesPaginacion(int no_pagina) {
            return await asignacionesDAO.GetAsignacionesPaginacion(no_pagina);
        }

        public async Task<Asignacion> GetAsignacion(int id_asignacion) {
            return await asignacionesDAO.GetAsignacion(id_asignacion);
        }
        
        public async Task<bool> CrearAsignacion(Asignacion asignacion) {
            return await asignacionesDAO.CrearAsignacion(asignacion);
        }

        public async Task<bool> ActualizarAsignacion(int id_asignacion, Asignacion asignacion) {
            return await asignacionesDAO.ActualizarAsignacion(id_asignacion, asignacion);
        }

        public async Task<bool> BorrarAsignacion(int id_asignacion) {
            return await asignacionesDAO.BorrarAsignacion(id_asignacion);
        }
    }
}