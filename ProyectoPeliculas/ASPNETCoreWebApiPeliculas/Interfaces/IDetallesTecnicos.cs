using System.Threading.Tasks;
using System.Collections.Generic;
using ASPNETCoreWebApiPeliculas.Models;

namespace ASPNETCoreWebApiPeliculas 
{
    public interface IDetallesTecnicos
    {
        Task<bool> CrearFormato(Formato formato);
        Task<List<Formato>> GetFormatos();
        Task<bool> ActualizarFormato(Formato formato);
        Task<bool> EliminarFormato(int id_formato);
        Task<bool> CrearTipoResolucion(TipoResolucion tipoResolucion);
        Task<List<TipoResolucion>> GetTiposResolucion();
        Task<bool> ActualizarTipoResolucion(TipoResolucion tipoResolucion);
        Task<bool> EliminarTipoResolucion(int id_tipo_resolucion);
        Task<bool> CrearValorResolucion(ValorResolucion valorResolucion);
        Task<List<ValorResolucion>> GetValoresResolucion();
        Task<bool> ActualizarValorResolucion(ValorResolucion valorResolucion);
        Task<bool> EliminarValorResolucion(int id_valor_resolucion);
        Task<bool> CrearRelacionAspecto(RelacionAspecto relacionAspecto);
        Task<List<RelacionAspecto>> GetRelacionesAspecto();
        Task<bool> ActualizarRelacionAspecto(RelacionAspecto relacionAspecto);
        Task<bool> EliminarRelacionAspecto(int id_relacion_aspecto);
        Task<bool> CrearResolucion(Resolucion resolucion);
        Task<bool> EliminarResolucion(int id_tipo_resolucion, int id_valor_resolucion, int id_relacion_aspecto);
        Task<bool> CrearDetalleTecnico(DetalleTecnico detalleTecnico);
        Task<bool> ActualizarDetalleTecnico(DetalleTecnico detalleTecnico);
        Task<bool> EliminarDetalleTecnico(int id_detalle);
    }
}