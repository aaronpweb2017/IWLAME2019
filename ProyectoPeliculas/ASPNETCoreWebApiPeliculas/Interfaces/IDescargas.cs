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
        Task<bool> CrearDescarga(Descarga descarga);
        Task<List<Descarga>> GetDescargas();
        Task<bool> ActualizarDescarga(Descarga descarga);
        Task<bool> EliminarDescarga(int id_descarga);
        Task<bool> CrearEnlace(Enlace enlace);
        Task<bool> ActualizarEnlace(Enlace enlace);
        Task<bool> EliminarEnlace(int id_enlace);
        Task<List<Enlace>> GetEnlacesDescarga(int id_descarga);
    }
}