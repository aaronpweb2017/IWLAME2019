using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiORAGestionRecursos.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebApiORAGestionRecursos 
{
    public class AsignacionesDomainObject
    {
        AsignacionesDAO asignacionesDAO;
        public AsignacionesDomainObject(AsignacionContext asignacionContext) {
            asignacionesDAO = new AsignacionesDAO(asignacionContext);
        }

        public async Task<List<Asignacion>> GetAsignaciones() {
            return await asignacionesDAO.GetAsignaciones();
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