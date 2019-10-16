using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreWebApiPeliculas.Models;
using Microsoft.AspNetCore.Authorization;

namespace ASPNETCoreWebApiPeliculas.Controllers
{
    [ApiController] [Route("Api/[controller]/[action]")] [Authorize]
    public class DetallesTecnicosController : ControllerBase
    {
        private readonly IDetallesTecnicos detallesTecnicos;

        public DetallesTecnicosController(IDetallesTecnicos detallesTecnicos) {
            this.detallesTecnicos = detallesTecnicos;
        }

        //POST: https://189.186.51.66:443/Api/DetallesTecnicos/CrearFormato
        [HttpPost] [ActionName("CrearFormato")]
        public async Task<Object []> CreateFormatAsync([FromBody] Formato formato) {
            return await detallesTecnicos.CrearFormato(formato);
        }

        //GET: https://189.186.51.66:443/Api/DetallesTecnicos/GetFormatos
        [HttpGet] [ActionName("GetFormatos")]
        public async Task<Object []> GetFormatsAsync() {
            return await detallesTecnicos.GetFormatos();
        }

        //PUT: https://189.186.51.66:443/Api/DetallesTecnicos/ActualizarFormato
        [HttpPut] [ActionName("ActualizarFormato")]
        public async Task<Object []> UpdateFormatAsync([FromBody] Formato formato) {
            return await detallesTecnicos.ActualizarFormato(formato);
        }

        //DELETE: https://189.186.51.66:443/Api/DetallesTecnicos/EliminarFormato?id_formato=[value]
        [HttpDelete] [ActionName("EliminarFormato")]
        public async Task<Object []> DeleteFormatTypeAsync(int id_formato) {
            return await detallesTecnicos.EliminarFormato(id_formato);
        }

        //POST: https://189.186.51.66:443/Api/DetallesTecnicos/CrearTipoResolucion
        [HttpPost] [ActionName("CrearTipoResolucion")]
        public async Task<Object []> CreateResolutionTypeAsync([FromBody] TipoResolucion tipoResolucion) {
            return await detallesTecnicos.CrearTipoResolucion(tipoResolucion);
        }

        //GET: https://189.186.51.66:443/Api/DetallesTecnicos/GetTiposResolucion
        [HttpGet] [ActionName("GetTiposResolucion")]
        public async Task<Object []> GetResolutionTypesAsync() {
            return await detallesTecnicos.GetTiposResolucion();
        }

        //PUT: https://189.186.51.66:443/Api/DetallesTecnicos/ActualizarTipoResolucion
        [HttpPut] [ActionName("ActualizarTipoResolucion")]
        public async Task<Object []> UpdateResolutionTypeAsync([FromBody] TipoResolucion tipoResolucion) {
            return await detallesTecnicos.ActualizarTipoResolucion(tipoResolucion);
        }

        //DELETE: https://189.186.51.66:443/Api/DetallesTecnicos/EliminarTipoResolucion?id_tipo_resolucion=[value]
        [HttpDelete] [ActionName("EliminarTipoResolucion")]
        public async Task<Object []> DeleteResolutionTypeAsync(int id_tipo_resolucion) {
            return await detallesTecnicos.EliminarTipoResolucion(id_tipo_resolucion);
        }

        //POST: https://189.186.51.66:443/Api/DetallesTecnicos/CrearValorResolucion
        [HttpPost] [ActionName("CrearValorResolucion")]
        public async Task<Object []> CreateResolutionValueAsync([FromBody] ValorResolucion valorResolucion) {
            return await detallesTecnicos.CrearValorResolucion(valorResolucion);
        }

        //GET: https://189.186.51.66:443/Api/DetallesTecnicos/GetValoresResolucion
        [HttpGet] [ActionName("GetValoresResolucion")]
        public async Task<Object []> GetResolutionValuesAsync() {
            return await detallesTecnicos.GetValoresResolucion();
        }

        //PUT: https://189.186.51.66:443/Api/DetallesTecnicos/ActualizarValorResolucion
        [HttpPut] [ActionName("ActualizarValorResolucion")]
        public async Task<Object []> UpdateResolutionValueAsync([FromBody] ValorResolucion valorResolucion) {
            return await detallesTecnicos.ActualizarValorResolucion(valorResolucion);
        }

        //DELETE: https://189.186.51.66:443/Api/DetallesTecnicos/EliminarValorResolucion?id_valor_resolucion=[value]
        [HttpDelete] [ActionName("EliminarValorResolucion")]
        public async Task<Object []> DeleteResolutionValueAsync(int id_valor_resolucion) {
            return await detallesTecnicos.EliminarValorResolucion(id_valor_resolucion);
        }

        //POST: https://189.186.51.66:443/Api/DetallesTecnicos/CrearRelacionAspecto
        [HttpPost] [ActionName("CrearRelacionAspecto")]
        public async Task<Object []> CreateAspectRatioAsync([FromBody] RelacionAspecto relacionAspecto) {
            return await detallesTecnicos.CrearRelacionAspecto(relacionAspecto);
        }

        //GET: https://189.186.51.66:443/Api/DetallesTecnicos/GetRelacionesAspecto
        [HttpGet] [ActionName("GetRelacionesAspecto")]
        public async Task<Object []> GetAspectRatiosAsync() {
            return await detallesTecnicos.GetRelacionesAspecto();
        }

        //PUT: https://189.186.51.66:443/Api/DetallesTecnicos/ActualizarRelacionAspecto
        [HttpPut] [ActionName("ActualizarRelacionAspecto")]
        public async Task<Object []> UpdateAspectRatioAsync([FromBody] RelacionAspecto relacionAspecto) {
            return await detallesTecnicos.ActualizarRelacionAspecto(relacionAspecto);
        }

        //DELETE: https://189.186.51.66:443/Api/DetallesTecnicos/EliminarRelacionAspecto?id_relacion_aspecto=[value]
        [HttpDelete] [ActionName("EliminarRelacionAspecto")]
        public async Task<Object []> DeleteAspectRatioAsync(int id_relacion_aspecto) {
            return await detallesTecnicos.EliminarRelacionAspecto(id_relacion_aspecto);
        }

        //POST: https://189.186.51.66:443/Api/DetallesTecnicos/CrearResolucion
        [HttpPost] [ActionName("CrearResolucion")]
        public async Task<Object []> CreateResolutionAsync([FromBody] Resolucion resolucion) {
            return await detallesTecnicos.CrearResolucion(resolucion);
        }

        //DELETE: https://189.186.51.66:443/Api/DetallesTecnicos/EliminarResolucion?id_tipo_resolucion=[value]&id_valor_resolucion=[value]&id_relacion_aspecto=[value]
        [HttpDelete] [ActionName("EliminarResolucion")]
        public async Task<Object []> DeleteResolutionAsync(int id_tipo_resolucion, int id_valor_resolucion, int id_relacion_aspecto) {
            return await detallesTecnicos.EliminarResolucion(id_tipo_resolucion, id_valor_resolucion, id_relacion_aspecto);
        }

        //POST: https://189.186.51.66:443/Api/DetallesTecnicos/CrearDetalleTecnico
        [HttpPost] [ActionName("CrearDetalleTecnico")]
        public async Task<Object []> CreateTechnicalDetailAsync([FromBody] DetalleTecnico detalleTecnico) {
            return await detallesTecnicos.CrearDetalleTecnico(detalleTecnico);
        }

        //PUT: https://189.186.51.66:443/Api/DetallesTecnicos/ActualizarDetalleTecnico
        [HttpPut] [ActionName("ActualizarDetalleTecnico")]
        public async Task<Object []> UpdateTechnicalDetailAsync([FromBody] DetalleTecnico detalleTecnico) {
            return await detallesTecnicos.ActualizarDetalleTecnico(detalleTecnico);
        }

        //DELETE: https://189.186.51.66:443/Api/DetallesTecnicos/EliminarDetalleTecnico?id_detalle=[value]
        [HttpDelete] [ActionName("EliminarDetalleTecnico")]
        public async Task<Object []> DeleteTechnicalDetailAsync(int id_detalle) {
            return await detallesTecnicos.EliminarDetalleTecnico(id_detalle);
        }
    }
}