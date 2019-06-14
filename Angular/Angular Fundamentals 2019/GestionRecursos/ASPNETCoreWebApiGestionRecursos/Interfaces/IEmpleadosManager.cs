using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiORAGestionRecursos.Models;

namespace ASPNETCoreWebApiORAGestionRecursos 
{
    public interface IEmpleadosManager
    {
        Task<int> GetNoEmpleados();
        Task<List<Empleado>> GetEmpleados();
        Task<List<Empleado>> GetEmpleadosPaginacion(int no_pagina);
        Task<Empleado> GetEmpleado(int id_empleado);
        Task<bool> CrearEmpleado(Empleado empleado);
        Task<bool> ActualizarEmpleado(int id_empleado, Empleado empleado);
        Task<bool> BorrarEmpleado(int id_empleado);
    } 
}