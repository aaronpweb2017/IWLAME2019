using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiORAGestionRecursos.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebApiORAGestionRecursos 
{
    public class AsignacionesRepository
    {
        private readonly AsignacionContext asignacionContext;
        public AsignacionesRepository(AsignacionContext asignacionContext) {
            this.asignacionContext = asignacionContext;
        }

        public async Task<List<Asignacion>> GetAsignaciones() {    
            return await asignacionContext.asignaciones.ToListAsync();
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