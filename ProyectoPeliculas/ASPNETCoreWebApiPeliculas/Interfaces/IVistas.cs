using System;
using System.Threading.Tasks;
using ASPNETCoreWebApiPeliculas.Views;

namespace ASPNETCoreWebApiPeliculas
{
    public interface IVistas
    {
        Task<Object []> GetVistaSolicitudes();
        Task<Object []> GetVistaTokens();
        Task<Object []> GetVistaResoluciones();
        Task<Object []> GetVistaDetallesTecnicos();
        Task<Object []> GetVistaDetalleTecnicoPelicula(int id_pelicula);
        Task<Object []> GetVistaDescargas();
    }
}