using System;
using System.Threading.Tasks;
using ASPNETCoreWebApiPeliculas.Models;

namespace ASPNETCoreWebApiPeliculas 
{
    public interface IDetallesTecnicos
    {
        Task<Object []> CrearFormato(Formato formato);
        Task<Object []> GetFormatos();
        Task<Object []> ActualizarFormato(Formato formato);
        Task<Object []> EliminarFormato(int id_formato);
        Task<Object []> CrearTipoResolucion(TipoResolucion tipoResolucion);
        Task<Object []> GetTiposResolucion();
        Task<Object []> ActualizarTipoResolucion(TipoResolucion tipoResolucion);
        Task<Object []> EliminarTipoResolucion(int id_tipo_resolucion);
        Task<Object []> CrearValorResolucion(ValorResolucion valorResolucion);
        Task<Object []> GetValoresResolucion();
        Task<Object []> ActualizarValorResolucion(ValorResolucion valorResolucion);
        Task<Object []> EliminarValorResolucion(int id_valor_resolucion);
        Task<Object []> CrearRelacionAspecto(RelacionAspecto relacionAspecto);
        Task<Object []> GetRelacionesAspecto();
        Task<Object []> ActualizarRelacionAspecto(RelacionAspecto relacionAspecto);
        Task<Object []> EliminarRelacionAspecto(int id_relacion_aspecto);
        Task<Object []> CrearResolucion(Resolucion resolucion);
        Task<Object []> EliminarResolucion(int id_tipo_resolucion, int id_valor_resolucion, int id_relacion_aspecto);
        Task<Object []> CrearDetalleTecnico(DetalleTecnico detalleTecnico);
        Task<Object []> ActualizarDetalleTecnico(DetalleTecnico detalleTecnico);
        Task<Object []> EliminarDetalleTecnico(int id_detalle);
    }
}