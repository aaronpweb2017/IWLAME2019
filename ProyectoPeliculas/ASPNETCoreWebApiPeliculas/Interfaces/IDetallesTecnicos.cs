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
        Task<bool> EliminarFormato(Formato formato);
        Task<bool> CrearTipoResolucion(TipoResolucion tipoResolucion);
        Task<List<TipoResolucion>> GetTiposResolucion();
        Task<bool> ActualizarTipoResolucion(TipoResolucion tipoResolucion);
        Task<bool> EliminarTipoResolucion(TipoResolucion tipoResolucion);
        Task<bool> CrearValorResolucion(ValorResolucion valorResolucion);
        Task<List<ValorResolucion>> GetValoresResolucion();
        Task<bool> ActualizarValorResolucion(ValorResolucion valorResolucion);
        Task<bool> EliminarValorResolucion(ValorResolucion valorResolucion);
        Task<bool> CrearRelacionAspecto(RelacionAspecto relacionAspecto);
        Task<List<RelacionAspecto>> GetRelacionesAspecto();
        Task<bool> ActualizarRelacionAspecto(RelacionAspecto relacionAspecto);
        Task<bool> EliminarRelacionAspecto(RelacionAspecto relacionAspecto);
        Task<bool> CrearResolucion(Resolucion resolucion);
        Task<List<Resolucion>> GetResoluciones();
        Task<bool> EliminarResolucion(Resolucion resolucion);
        Task<bool> CrearDetalleTecnico(DetalleTecnico detalleTecnico);
        Task<List<DetalleTecnico>> GetDetallesTecnicos();
        Task<bool> ActualizarDetalleTecnico(DetalleTecnico detalleTecnico);
        Task<bool> EliminarDetalleTecnico(DetalleTecnico detalleTecnico);
    }
}