using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiPeliculas.Views;

namespace ASPNETCoreWebApiPeliculas
{
    public interface IVistas
    {
        Task<List<VSolicitud>> GetVistaSolicitudes();
        Task<List<VToken>> GetVistaTokens();
        Task<List<VResolucion>> GetVistaResoluciones();
        Task<List<VDetalleTecnico>> GetVistaDetallesTecnicos();
        Task<VDetalleTecnico> GetVistaDetalleTecnicoPelicula(int id_pelicula);
        Task<List<VDescarga>> GetVistaDescargas();
    }
}