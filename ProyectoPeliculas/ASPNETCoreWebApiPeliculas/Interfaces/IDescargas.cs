using System.Threading.Tasks;
using System.Collections.Generic;
using ASPNETCoreWebApiPeliculas.Models;

namespace ASPNETCoreWebApiPeliculas 
{
    public interface IDescargas
    {
        Task<bool> CrearTipoArchivo(TipoArchivo tipoArchivo);
        Task<List<TipoArchivo>> GetTiposArchivo();
        Task<bool> ActualizarTipoArchivo(TipoArchivo tipoArchivo);
        Task<bool> EliminarTipoArchivo(int id_tipo_archivo);
    }
}