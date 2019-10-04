using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ASPNETCoreWebApiPeliculas.Views;
using ASPNETCoreWebApiPeliculas.Models;

namespace ASPNETCoreWebApiPeliculas 
{
    public class VistasRepository : IVistas
    {
        private readonly ApplicationDbContext AppDbContext;
        public VistasRepository(ApplicationDbContext AppDbContext) {
            this.AppDbContext = AppDbContext;
        }

        public async Task<Object []> GetVistaSolicitudes() {
            Object [] response = new Object [2];
            try {
                response[0] = await AppDbContext.vSolicitudes.ToListAsync();
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> GetVistaTokens() {
            Object [] response = new Object [2];
            try {
                response[0] = await AppDbContext.vTokens.ToListAsync();
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> GetVistaResoluciones() {
            Object [] response = new Object [2];
            try {
                response[0] = await AppDbContext.vResoluciones.ToListAsync();
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> GetVistaDetallesTecnicos() {
            Object [] response = new Object [2];
            try {
                response[0] = await AppDbContext.vDetallesTecnicos.ToListAsync();
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> GetVistaDetalleTecnicoPelicula(int id_pelicula) {
            Object [] response = new Object [2];
            try {
                 Pelicula movieToGetTechnicalDetail = await AppDbContext.peliculas.
                    Where(p => p.id_pelicula == id_pelicula).FirstOrDefaultAsync();
                response[0] =  await AppDbContext.vDetallesTecnicos.Where(dt =>
                    dt.id_detalle == movieToGetTechnicalDetail.id_detalle).FirstOrDefaultAsync();
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> GetVistaDescargas() {
            Object [] response = new Object [2];
            try {
                response[0] = await AppDbContext.vDescargas.ToListAsync();
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }
    }
}