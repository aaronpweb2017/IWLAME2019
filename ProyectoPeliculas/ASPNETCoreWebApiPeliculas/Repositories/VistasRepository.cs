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

        public async Task<List<VSolicitud>> GetVistaSolicitudes() {
            return await AppDbContext.vSolicitudes.ToListAsync();
        }

        public async Task<List<VToken>> GetVistaTokens() {
            return await AppDbContext.vTokens.ToListAsync();
        }

        public async Task<List<VResolucion>> GetVistaResoluciones() {
            return await AppDbContext.vResoluciones.ToListAsync();
        }

        public async Task<List<VDetalleTecnico>> GetVistaDetallesTecnicos() {
            return await AppDbContext.vDetallesTecnicos.ToListAsync();
        }
        public async Task<VDetalleTecnico> GetVistaDetalleTecnicoPelicula(int id_pelicula) {
            try {
                 Pelicula movieToGetTechnicalDetail = await AppDbContext.peliculas.
                    Where(p => p.id_pelicula == id_pelicula).FirstOrDefaultAsync();
                return await AppDbContext.vDetallesTecnicos.Where(dt =>
                    dt.id_detalle == movieToGetTechnicalDetail.id_detalle).FirstOrDefaultAsync();
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
                return null; 
            }
        }

        public async Task<List<VDescarga>> GetVistaDescargas() {
            return await AppDbContext.vDescargas.ToListAsync();
        }
    }
}