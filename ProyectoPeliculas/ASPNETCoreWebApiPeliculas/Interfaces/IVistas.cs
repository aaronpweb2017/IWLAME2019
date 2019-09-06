using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiPeliculas.Views;

namespace ASPNETCoreWebApiPeliculas
{
    public interface IVistas
    {
        Task<List<VSolicitud>> GetSolicitudesVista();
        Task<List<VToken>> GetTokensVista();
    }
}