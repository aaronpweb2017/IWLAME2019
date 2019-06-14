using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiORAGestionRecursos.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebApiORAGestionRecursos 
{
    public class EmpleadosDAO
    {
        EmpleadosRepository empleadosRepository;
        public EmpleadosDAO(EmpleadoContext empleadoContext) {
            empleadosRepository = new EmpleadosRepository(empleadoContext);
        }

        public async Task<int> GetNoEmpleados() {    
            return await empleadosRepository.GetNoEmpleados();
        }

        public async Task<List<Empleado>> GetEmpleados() {    
            return await empleadosRepository.GetEmpleados();
        }

        public async Task<List<Empleado>> GetEmpleadosPaginacion(int no_pagina) {
            return await empleadosRepository.GetEmpleadosPaginacion(no_pagina);
        }

        public async Task<Empleado> GetEmpleado(int id_empleado) {    
            return await empleadosRepository.GetEmpleado(id_empleado);
        }
        
        public async Task<bool> CrearEmpleado(Empleado empleado) {    
            return await empleadosRepository.CrearEmpleado(empleado);
        }

        public async Task<bool> ActualizarEmpleado(int id_empleado, Empleado empleado) {
            return await empleadosRepository.ActualizarEmpleado(id_empleado, empleado);
        }

        public async Task<bool> BorrarEmpleado(int id_empleado) {
            return await empleadosRepository.BorrarEmpleado(id_empleado);
        }
    }
}