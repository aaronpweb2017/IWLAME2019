using System;
using System.Threading.Tasks;
using ASPNETCoreWebApiPeliculas.Models;

namespace ASPNETCoreWebApiPeliculas 
{
    public interface IDescargas
    {
        Task<Object []> CrearTipoArchivo(TipoArchivo tipoArchivo);
        Task<Object []> GetTiposArchivo();
        Task<Object []> ActualizarTipoArchivo(TipoArchivo tipoArchivo);
        Task<Object []> EliminarTipoArchivo(int id_tipo_archivo);
        Task<Object []> CrearServidor(Servidor servidor);
        Task<Object []> GetServidores();
        Task<Object []> ActualizarServidor(Servidor servidor);
        Task<Object []> EliminarServidor(int id_servidor);
        Task<Object []> CrearDescarga(Descarga descarga);
        Task<Object []> GetDescargas();
        Task<Object []> ActualizarDescarga(Descarga descarga);
        Task<Object []> EliminarDescarga(int id_descarga);
        Task<Object []> CrearEnlace(Enlace enlace);
        Task<Object []> ActualizarEnlace(Enlace enlace);
        Task<Object []> EliminarEnlace(int id_enlace);
        Task<Object []> GetEnlacesDescarga(int id_descarga);
    }
}