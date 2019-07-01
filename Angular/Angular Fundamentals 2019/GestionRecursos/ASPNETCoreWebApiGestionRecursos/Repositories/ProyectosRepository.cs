using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ASPNETCoreWebApiORAGestionRecursos.Models;

namespace ASPNETCoreWebApiORAGestionRecursos 
{
    public class ProyectosRepository
    {
        private readonly ProyectoContext proyectoContext;
        public ProyectosRepository(ProyectoContext proyectoContext) {
            this.proyectoContext = proyectoContext;
        }

        public async Task<int> GetNoProyectos() {
            return await proyectoContext.proyectos.CountAsync();
        }        

        public async Task<List<Proyecto>> GetProyectos() {    
            return await proyectoContext.proyectos.ToListAsync();
        }

        public async Task<List<Proyecto>> GetProyectosPaginacion(int no_pagina) {
            return await proyectoContext.proyectos.Skip(5*(no_pagina-1)).Take(5).ToListAsync();
        }

        public async Task<Proyecto> GetProyecto(int id_proyecto) {    
            return await proyectoContext.proyectos.FindAsync(id_proyecto);
        }
        
        public async Task<bool> CrearProyecto(Proyecto proyecto) {    
            bool response = false;
            try {
                await proyectoContext.AddAsync(proyecto);
                await proyectoContext.SaveChangesAsync();
                response = true;
            }
            catch(Exception exception) {
                ShowExceptionMessage(exception);
            }
            return response;
        }

        public async Task<bool> ActualizarProyecto(int id_proyecto, Proyecto proyecto) {
            bool response = false;
            try {
                proyecto.id_proyecto = id_proyecto;
                proyectoContext.Update(proyecto);
                await proyectoContext.SaveChangesAsync();
                response = true;
            }
            catch(Exception exception) {
                ShowExceptionMessage(exception);
            }
            return response;
        }

        public async Task<bool> BorrarProyecto(int id_proyecto) {
            bool response = false;
            try {
                Proyecto proyecto = GetProyecto(id_proyecto).Result;
                if(proyecto==null) return response;
                proyectoContext.Remove(proyecto);
                await proyectoContext.SaveChangesAsync();
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