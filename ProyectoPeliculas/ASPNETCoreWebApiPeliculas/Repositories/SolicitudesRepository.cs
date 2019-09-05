using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiPeliculas.Models;
using ASPNETCoreWebApiPeliculas.Views;
using Microsoft.EntityFrameworkCore;


namespace ASPNETCoreWebApiPeliculas 
{
    public class SolicitudesRepository : ISolicitudes
    {
        private readonly ApplicationDbContext AppDbContext;
        public SolicitudesRepository(ApplicationDbContext AppDbContext) {
            this.AppDbContext = AppDbContext;
        }
        
        public async Task<int> GetNoSolicitudes() {
            return await AppDbContext.usuariosSolicitudes.CountAsync();
        }

        public async Task<bool> AprobarSolicitud(int id_usuario_solicitud) {
            bool response = false;
            try {
                UsuarioSolicitud solicitud = await AppDbContext.usuariosSolicitudes.FindAsync(id_usuario_solicitud);
                solicitud.status_solicitud = 1; solicitud.aprobacion_solicitud = DateTime.Now;
                AppDbContext.usuariosSolicitudes.Update(solicitud); await AppDbContext.SaveChangesAsync();
                response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<List<VSolicitud>> GetSolicitudesViewPaginacion(int no_pagina) {
            return await AppDbContext.vSolicitudes.Skip(10*(no_pagina-1)).Take(10).ToListAsync();
        }
    }
}