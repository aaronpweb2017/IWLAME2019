using System;
using System.Linq;
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

        public async Task<List<VSolicitud>> GetSolicitudesVista() {
            return await AppDbContext.vSolicitudes.ToListAsync();
        }

        public async Task<List<VToken>> GetTokensVista() {
            return await AppDbContext.vTokens.ToListAsync();
        }
    }
}