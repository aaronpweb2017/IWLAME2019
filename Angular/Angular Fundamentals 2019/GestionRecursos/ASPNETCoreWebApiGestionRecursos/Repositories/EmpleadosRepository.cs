using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiORAGestionRecursos.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebApiORAGestionRecursos 
{
    public class EmpleadosRepository
    {
        private readonly EmpleadoContext empleadoContext;
        public EmpleadosRepository(EmpleadoContext empleadoContext) {
            this.empleadoContext = empleadoContext;
        }

        public async Task<List<Empleado>> GetEmpleados() {    
            return await empleadoContext.empleados.ToListAsync();
        }

        public async Task<Empleado> GetEmpleado(int id_empleado) {    
            return await empleadoContext.empleados.FindAsync(id_empleado);
        }
        
        public async Task<bool> CrearEmpleado(Empleado empleado) {    
            bool response = false;
            try {
                await empleadoContext.AddAsync(empleado);
                await empleadoContext.SaveChangesAsync();
                response = true;
            }
            catch(Exception exception) {
                ShowExceptionMessage(exception);
            }
            return response;
        }

        public async Task<bool> ActualizarEmpleado(int id_empleado, Empleado empleado) {
            bool response = false;
            try {
                empleado.id_empleado = id_empleado;
                empleadoContext.Update(empleado);
                await empleadoContext.SaveChangesAsync();
                response = true;
            }
            catch(Exception exception) {
                ShowExceptionMessage(exception);
            }
            return response;
        }

        public async Task<bool> BorrarEmpleado(int id_empleado) {
            bool response = false;
            try {
                Empleado empleado = GetEmpleado(id_empleado).Result;
                if(empleado==null) return response;
                empleadoContext.Remove(empleado);
                await empleadoContext.SaveChangesAsync();
                response = true;
            }
            catch(Exception exception) {
                ShowExceptionMessage(exception);
            }
            return response;
        }
        
        public void ShowExceptionMessage(Exception exception) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Mensaje: "+exception.Message);
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}