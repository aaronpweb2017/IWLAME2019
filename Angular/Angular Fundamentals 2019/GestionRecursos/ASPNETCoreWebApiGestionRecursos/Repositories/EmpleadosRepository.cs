using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ASPNETCoreWebApiORAGestionRecursos.Models;

namespace ASPNETCoreWebApiORAGestionRecursos 
{
    public class EmpleadosRepository
    {
        private readonly EmpleadoContext empleadoContext;
        private readonly AsignacionContext asignacionContext;
        private readonly ProyectoContext proyectoContext;

        public EmpleadosRepository(EmpleadoContext empleadoContext,
        AsignacionContext asignacionContext, ProyectoContext proyectoContext) {
            this.empleadoContext = empleadoContext;
            this.asignacionContext = asignacionContext;
            this.proyectoContext = proyectoContext;
        }

        public async Task<int> GetNoEmpleados() {
            return await empleadoContext.empleados.CountAsync();
        }

        public async Task<List<Empleado>> GetEmpleados() {
            return await empleadoContext.empleados.ToListAsync();
        }

        public async Task<List<Empleado>> GetEmpleadosActivos() {
            return await empleadoContext.empleados.Where(
            empleado => empleado.status==1).ToListAsync();
        }

        public async Task<int[]> GetAsignadosPaginacion(int no_pagina) {
            int[] asignados; Asignacion asignacion;
            List<Empleado> empleados = await GetEmpleadosPaginacion(no_pagina);
            asignados = new int[empleados.Count];
            for(int i = 0; i < empleados.Count; i++) {
                asignacion = await asignacionContext.asignaciones.Where(assignment =>
                assignment.id_empleado == empleados[i].id_empleado).FirstOrDefaultAsync();
                if(asignacion != null) asignados[i] = 1;
            }
            return asignados;
        }

        public async Task<List<Empleado>> GetEmpleadosPaginacion(int no_pagina) {
            return await empleadoContext.empleados.Skip(5*(no_pagina-1)).Take(5).ToListAsync();
        }

        public async Task<Empleado> GetEmpleado(int id_empleado) {
            return await empleadoContext.empleados.FindAsync(id_empleado);
        }

        public async Task<bool> GetEmpleadoTrabajando(int id_empleado) {
            List<Asignacion> asignaciones = await asignacionContext.asignaciones.
            Where(asignacion => asignacion.id_empleado == id_empleado).ToListAsync();
            bool trabajando = false; Proyecto proyecto;
            foreach(Asignacion asignacion in asignaciones) {
                proyecto = await proyectoContext.proyectos.FindAsync(asignacion.id_proyecto);
                if(proyecto.status == 1) { trabajando = true; break; }
            }
            return trabajando;
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