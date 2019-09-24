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
        Task<bool> CrearServidor(Servidor servidor);
        Task<List<Servidor>> GetServidores();
        Task<bool> ActualizarServidor(Servidor servidor);
        Task<bool> EliminarServidor(int id_servidor);
    }
}