using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ASPNETCoreWebApiPeliculas.Models;
//using Microsoft.AspNetCore.Authorization;

namespace ASPNETCoreWebApiPeliculas.Controllers
{
    [ApiController] [Route("Api/[controller]/[action]")] //[Authorize]
    public class DetallesTecnicosController : ControllerBase
    {
        private readonly IDetallesTecnicos detallesTecnicos;

        public DetallesTecnicosController(IDetallesTecnicos detallesTecnicos) {
            this.detallesTecnicos = detallesTecnicos;
        }

        //POST: https://localhost:5001/Api/DetallesTecnicos/CrearFormato
        [HttpPost] [ActionName("CrearFormato")]
        public async Task<bool> CreateFormatAsync([FromBody] Formato formato) {
            return await detallesTecnicos.CrearFormato(formato);
        }

        //GET: https://localhost:5001/Api/DetallesTecnicos/GetFormatos
        [HttpGet] [ActionName("GetFormatos")]
        public async Task<List<Formato>> GetFormatsAsync() {
            return await detallesTecnicos.GetFormatos();
        }

        //PUT: https://localhost:5001/Api/DetallesTecnicos/ActualizarFormato
        [HttpPut] [ActionName("ActualizarFormato")]
        public async Task<bool> UpdateFormatAsync([FromBody] Formato formato) {
            return await detallesTecnicos.ActualizarFormato(formato);
        }

        //DELETE: https://localhost:5001/Api/DetallesTecnicos/EliminarFormato?id_formato=[value]
        [HttpDelete] [ActionName("EliminarFormato")]
        public async Task<bool> DeleteFormatTypeAsync(int id_formato) {
            return await detallesTecnicos.EliminarFormato(id_formato);
        }

        //POST: https://localhost:5001/Api/DetallesTecnicos/CrearTipoResolucion
        [HttpPost] [ActionName("CrearTipoResolucion")]
        public async Task<bool> CreateResolutionTypeAsync([FromBody] TipoResolucion tipoResolucion) {
            return await detallesTecnicos.CrearTipoResolucion(tipoResolucion);
        }

        //GET: https://localhost:5001/Api/DetallesTecnicos/GetTiposResolucion
        [HttpGet] [ActionName("GetTiposResolucion")]
        public async Task<List<TipoResolucion>> GetResolutionTypesAsync() {
            return await detallesTecnicos.GetTiposResolucion();
        }

        //PUT: https://localhost:5001/Api/DetallesTecnicos/ActualizarTipoResolucion
        [HttpPut] [ActionName("ActualizarTipoResolucion")]
        public async Task<bool> UpdateResolutionTypeAsync([FromBody] TipoResolucion tipoResolucion) {
            return await detallesTecnicos.ActualizarTipoResolucion(tipoResolucion);
        }

        //DELETE: https://localhost:5001/Api/DetallesTecnicos/EliminarTipoResolucion?id_tipo_resolucion=[value]
        [HttpDelete] [ActionName("EliminarTipoResolucion")]
        public async Task<bool> DeleteResolutionTypeAsync(int id_tipo_resolucion) {
            return await detallesTecnicos.EliminarTipoResolucion(id_tipo_resolucion);
        }

        //POST: https://localhost:5001/Api/DetallesTecnicos/CrearValorResolucion
        [HttpPost] [ActionName("CrearValorResolucion")]
        public async Task<bool> CreateResolutionValueAsync([FromBody] ValorResolucion valorResolucion) {
            return await detallesTecnicos.CrearValorResolucion(valorResolucion);
        }

        //GET: https://localhost:5001/Api/DetallesTecnicos/GetValoresResolucion
        [HttpGet] [ActionName("GetValoresResolucion")]
        public async Task<List<ValorResolucion>> GetResolutionValuesAsync() {
            return await detallesTecnicos.GetValoresResolucion();
        }

        //PUT: https://localhost:5001/Api/DetallesTecnicos/ActualizarValorResolucion
        [HttpPut] [ActionName("ActualizarValorResolucion")]
        public async Task<bool> UpdateResolutionValueAsync([FromBody] ValorResolucion valorResolucion) {
            return await detallesTecnicos.ActualizarValorResolucion(valorResolucion);
        }

        //DELETE: https://localhost:5001/Api/DetallesTecnicos/EliminarValorResolucion?id_valor_resolucion=[value]
        [HttpDelete] [ActionName("EliminarValorResolucion")]
        public async Task<bool> DeleteResolutionValueAsync(int id_valor_resolucion) {
            return await detallesTecnicos.EliminarValorResolucion(id_valor_resolucion);
        }

        //POST: https://localhost:5001/Api/DetallesTecnicos/CrearRelacionAspecto
        [HttpPost] [ActionName("CrearRelacionAspecto")]
        public async Task<bool> CreateAspectRatioAsync([FromBody] RelacionAspecto relacionAspecto) {
            return await detallesTecnicos.CrearRelacionAspecto(relacionAspecto);
        }

        //GET: https://localhost:5001/Api/DetallesTecnicos/GetRelacionesAspecto
        [HttpGet] [ActionName("GetRelacionesAspecto")]
        public async Task<List<RelacionAspecto>> GetAspectRatiosAsync() {
            return await detallesTecnicos.GetRelacionesAspecto();
        }

        //PUT: https://localhost:5001/Api/DetallesTecnicos/ActualizarRelacionAspecto
        [HttpPut] [ActionName("ActualizarRelacionAspecto")]
        public async Task<bool> UpdateAspectRatioAsync([FromBody] RelacionAspecto relacionAspecto) {
            return await detallesTecnicos.ActualizarRelacionAspecto(relacionAspecto);
        }

        //DELETE: https://localhost:5001/Api/DetallesTecnicos/EliminarRelacionAspecto?id_relacion_aspecto=[value]
        [HttpDelete] [ActionName("EliminarRelacionAspecto")]
        public async Task<bool> DeleteAspectRatioAsync(int id_relacion_aspecto) {
            return await detallesTecnicos.EliminarRelacionAspecto(id_relacion_aspecto);
        }

        //POST: https://localhost:5001/Api/DetallesTecnicos/CrearResolucion
        [HttpPost] [ActionName("CrearResolucion")]
        public async Task<bool> CreateResolutionAsync([FromBody] Resolucion resolucion) {
            return await detallesTecnicos.CrearResolucion(resolucion);
        }

        //DELETE: https://localhost:5001/Api/DetallesTecnicos/EliminarResolucion?id_tipo_resolucion=[value]&id_valor_resolucion=[value]&id_relacion_aspecto=[value]
        [HttpDelete] [ActionName("EliminarResolucion")]
        public async Task<bool> DeleteResolutionAsync(int id_tipo_resolucion, int id_valor_resolucion, int id_relacion_aspecto) {
            return await detallesTecnicos.EliminarResolucion(id_tipo_resolucion, id_valor_resolucion, id_relacion_aspecto);
        }

        //POST: https://localhost:5001/Api/DetallesTecnicos/CrearDetalleTecnico
        [HttpPost] [ActionName("CrearDetalleTecnico")]
        public async Task<bool> CreateTechnicalDetailAsync([FromBody] DetalleTecnico detalleTecnico) {
            return await detallesTecnicos.CrearDetalleTecnico(detalleTecnico);
        }

        //PUT: https://localhost:5001/Api/DetallesTecnicos/ActualizarDetalleTecnico
        [HttpPut] [ActionName("ActualizarDetalleTecnico")]
        public async Task<bool> UpdateTechnicalDetailAsync([FromBody] DetalleTecnico detalleTecnico) {
            return await detallesTecnicos.ActualizarDetalleTecnico(detalleTecnico);
        }

        //DELETE: https://localhost:5001/Api/DetallesTecnicos/EliminarDetalleTecnico?id_detalle=[value]
        [HttpDelete] [ActionName("EliminarDetalleTecnico")]
        public async Task<bool> DeleteTechnicalDetailAsync(int id_detalle) {
            return await detallesTecnicos.EliminarDetalleTecnico(id_detalle);
        }
    }
}