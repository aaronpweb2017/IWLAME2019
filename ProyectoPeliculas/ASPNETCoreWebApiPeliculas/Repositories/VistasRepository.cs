using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiPeliculas.Views;
using Microsoft.EntityFrameworkCore;

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
    }
}