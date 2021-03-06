using System.Threading.Tasks;
using System.Collections.Generic;
using ASPNETCoreWebApiORAGestionRecursos.Models;

namespace ASPNETCoreWebApiORAGestionRecursos 
{
    public interface IAsignacionesManager
    {
        Task<int> GetNoAsignaciones();
        Task<List<Asignacion>> GetAsignaciones();
        Task<List<Asignacion>> GetAsignacionesPaginacion(int no_pagina);
        Task<List<Proyecto>> GetProyectosPaginacion(int no_pagina);
        Task<List<Empleado>> GetEmpleadosPaginacion(int no_pagina);
        Task<Asignacion> GetAsignacion(int id_asignacion);
        Task<bool> CrearAsignacion(Asignacion asignacion);
        Task<bool> ActualizarAsignacion(int id_asignacion, Asignacion asignacion);
        Task<bool> BorrarAsignacion(int id_asignacion);
    } 
}