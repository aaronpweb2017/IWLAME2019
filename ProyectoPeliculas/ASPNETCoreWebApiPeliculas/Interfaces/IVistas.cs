using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiPeliculas.Views;

namespace ASPNETCoreWebApiPeliculas
{
    public interface IVistas
    {
        Task<List<VSolicitud>> GetVistaSolicitudes();
        Task<List<VToken>> GetVistaTokens();
    }
}