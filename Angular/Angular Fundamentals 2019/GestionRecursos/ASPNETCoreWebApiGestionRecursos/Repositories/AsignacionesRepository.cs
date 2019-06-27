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
        public AsignacionesRepository(AsignacionContext asignacionContext) {
            this.asignacionContext = asignacionContext;
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

        public async Task<List<Asignacion>> GetAsignacionesEmpleados(int [] ids_empleados) {
            List<Asignacion> asignaciones = new List<Asignacion>();
            foreach(int id_empleado in ids_empleados) {
                asignaciones.Add(await asignacionContext.asignaciones.Where(asignacion =>
                    asignacion.id_empleado == id_empleado).FirstOrDefaultAsync());
            }
            return asignaciones;
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