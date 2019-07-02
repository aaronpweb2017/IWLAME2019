using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ASPNETCoreWebApiORAGestionRecursos.Models;

namespace ASPNETCoreWebApiORAGestionRecursos 
{
    public class AsignacionesRepository
    {
        private readonly AsignacionContext asignacionContext;
        private readonly ProyectoContext proyectoContext;
        private readonly EmpleadoContext empleadoContext;
        public AsignacionesRepository(AsignacionContext asignacionContext,
        ProyectoContext proyectoContext, EmpleadoContext empleadoContext) {
            this.asignacionContext = asignacionContext;
            this.proyectoContext = proyectoContext;
            this.empleadoContext = empleadoContext;
        }

        public async Task<int> GetNoAsignaciones() {
            return await asignacionContext.asignaciones.CountAsync();
        }  

        public async Task<List<Asignacion>> GetAsignaciones() {    
            return await asignacionContext.asignaciones.ToListAsync();
        }

        public async Task<List<Asignacion>> GetAsignacionesPaginacion(int no_pagina) {
            return await asignacionContext.asignaciones.Skip(5*(no_pagina-1)).Take(5).ToListAsync();
        }

        public async Task<List<Proyecto>> GetProyectosPaginacion(int no_pagina) {
            List<Asignacion> asignaciones = await GetAsignacionesPaginacion(no_pagina);
            List<Proyecto> proyectos = new List<Proyecto>();
            foreach(Asignacion asignacion in asignaciones)
                proyectos.Add(await proyectoContext.proyectos.FindAsync(asignacion.id_proyecto));
            return proyectos;
        }

        public async Task<List<Empleado>> GetEmpleadosPaginacion(int no_pagina) {
            List<Asignacion> asignaciones = await GetAsignacionesPaginacion(no_pagina);
            List<Empleado> empleados = new List<Empleado>();
            foreach(Asignacion asignacion in asignaciones)
                empleados.Add(await empleadoContext.empleados.FindAsync(asignacion.id_empleado));
            return empleados;
        }

        public async Task<Asignacion> GetAsignacion(int id_asignacion) {  
            return await asignacionContext.asignaciones.FindAsync(id_asignacion);
        }
        
        public async Task<bool> CrearAsignacion(Asignacion asignacion) {    
            bool response = false;
            try {
                await asignacionContext.AddAsync(asignacion);
                await asignacionContext.SaveChangesAsync();
                response = true;
            }
            catch(Exception exception) {
                ShowExceptionMessage(exception);
            }
            return response;
        }

        public async Task<bool> ActualizarAsignacion(int id_asignacion, Asignacion asignacion) {
            bool response = false;
            try {
                asignacion.id_asignacion = id_asignacion;
                asignacionContext.Update(asignacion);
                await asignacionContext.SaveChangesAsync();
                response = true;
            }
            catch(Exception exception) {
                ShowExceptionMessage(exception);
            }
            return response;
        }

        public async Task<bool> BorrarAsignacion(int id_asignacion) {
            bool response = false;
            try {
                Asignacion asignacion = GetAsignacion(id_asignacion).Result;
                if(asignacion==null) return response;
                asignacionContext.Remove(asignacion);
                await asignacionContext.SaveChangesAsync();
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