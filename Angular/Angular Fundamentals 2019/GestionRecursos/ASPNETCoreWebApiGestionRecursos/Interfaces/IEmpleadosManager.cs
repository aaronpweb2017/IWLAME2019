using System.Threading.Tasks;
using System.Collections.Generic;
using ASPNETCoreWebApiORAGestionRecursos.Models;

namespace ASPNETCoreWebApiORAGestionRecursos 
{
    public interface IEmpleadosManager
    {
        Task<int> GetNoEmpleados();
        Task<List<Empleado>> GetEmpleados();
        Task<List<Empleado>> GetEmpleadosActivos();
        Task<int[]> GetAsignadosPaginacion(int no_pagina);
        Task<List<Empleado>> GetEmpleadosPaginacion(int no_pagina);
        Task<Empleado> GetEmpleado(int id_empleado);
        Task<bool> GetEmpleadoTrabajando(int id_empleado);
        Task<bool> CrearEmpleado(Empleado empleado);
        Task<bool> ActualizarEmpleado(int id_empleado, Empleado empleado);
        Task<bool> BorrarEmpleado(int id_empleado);
    } 
}