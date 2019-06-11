using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiORAGestionRecursos.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebApiORAGestionRecursos 
{
    public class AsignacionesDAO
    {
        AsignacionesRepository asignacionesRepository;
        public AsignacionesDAO(AsignacionContext asignacionContext) {
            asignacionesRepository = new AsignacionesRepository(asignacionContext);
        }

        public async Task<List<Asignacion>> GetAsignaciones() {
            return await asignacionesRepository.GetAsignaciones();
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