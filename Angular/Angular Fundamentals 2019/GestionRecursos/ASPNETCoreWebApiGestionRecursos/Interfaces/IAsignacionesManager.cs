using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiORAGestionRecursos.Models;

namespace ASPNETCoreWebApiORAGestionRecursos 
{
    public interface IAsignacionesManager
    {
        Task<List<Asignacion>> GetAsignaciones();
        Task<Asignacion> GetAsignacion(int id_asignacion);
        Task<bool> CrearAsignacion(Asignacion asignacion);
        Task<bool> ActualizarAsignacion(int id_asignacion, Asignacion asignacion);
        Task<bool> BorrarAsignacion(int id_asignacion);
    } 
}