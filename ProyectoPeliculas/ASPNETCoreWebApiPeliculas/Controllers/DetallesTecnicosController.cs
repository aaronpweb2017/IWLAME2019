using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ASPNETCoreWebApiPeliculas.Models;
using Microsoft.AspNetCore.Authorization;

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

        //PUT: https://localhost:5001/Api/DetallesTecnicos/EliminarFormato
        [HttpDelete] [ActionName("EliminarFormato")]
        public async Task<bool> DeleteFormatTypeAsync([FromBody] Formato formato) {
            return await detallesTecnicos.EliminarFormato(formato);
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

        //PUT: https://localhost:5001/Api/DetallesTecnicos/EliminarTipoResolucion
        [HttpDelete] [ActionName("EliminarTipoResolucion")]
        public async Task<bool> DeleteResolutionTypeAsync([FromBody] TipoResolucion tipoResolucion) {
            return await detallesTecnicos.EliminarTipoResolucion(tipoResolucion);
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

        //PUT: https://localhost:5001/Api/DetallesTecnicos/EliminarValorResolucion
        [HttpDelete] [ActionName("EliminarValorResolucion")]
        public async Task<bool> DeleteResolutionValueAsync([FromBody] ValorResolucion valorResolucion) {
            return await detallesTecnicos.EliminarValorResolucion(valorResolucion);
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

        //PUT: https://localhost:5001/Api/DetallesTecnicos/EliminarRelacionAspecto
        [HttpDelete] [ActionName("EliminarRelacionAspecto")]
        public async Task<bool> DeleteAspectRatioAsync([FromBody] RelacionAspecto relacionAspecto) {
            return await detallesTecnicos.EliminarRelacionAspecto(relacionAspecto);
        }

        //POST: https://localhost:5001/Api/DetallesTecnicos/CrearResolucion
        [HttpPost] [ActionName("CrearResolucion")]
        public async Task<bool> CreateResolutionAsync([FromBody] Resolucion resolucion) {
            return await detallesTecnicos.CrearResolucion(resolucion);
        }

        //PUT: https://localhost:5001/Api/DetallesTecnicos/EliminarResolucion
        [HttpDelete] [ActionName("EliminarResolucion")]
        public async Task<bool> DeleteResolutionAsync([FromBody] Resolucion resolucion) {
            return await detallesTecnicos.EliminarResolucion(resolucion);
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

        //PUT: https://localhost:5001/Api/DetallesTecnicos/EliminarDetalleTecnico
        [HttpDelete] [ActionName("EliminarDetalleTecnico")]
        public async Task<bool> DeleteTechnicalDetailAsync([FromBody] DetalleTecnico detalleTecnico) {
            return await detallesTecnicos.EliminarDetalleTecnico(detalleTecnico);
        }
    }
}