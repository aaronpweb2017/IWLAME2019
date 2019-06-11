using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiORAGestionRecursos.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebApiORAGestionRecursos 
{
    public class AsignacionesManager : IAsignacionesManager
    {
        AsignacionesDomainObject asignacionesDO;
        public AsignacionesManager(AsignacionContext asignacionContext) {
            asignacionesDO = new AsignacionesDomainObject(asignacionContext);
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