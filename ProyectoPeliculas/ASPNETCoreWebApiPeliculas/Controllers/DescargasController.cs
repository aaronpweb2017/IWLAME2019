using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ASPNETCoreWebApiPeliculas.Models;
//using Microsoft.AspNetCore.Authorization;

namespace ASPNETCoreWebApiPeliculas.Controllers
{
    [ApiController] [Route("Api/[controller]/[action]")] //[Authorize]
    public class DescargasController : ControllerBase
    {
        private readonly IDescargas descargas;
        
        public DescargasController(IDescargas descargas) {
            this.descargas = descargas;
        }

        //POST: https://localhost:5001/Api/Descargas/CrearTipoArchivo
        [HttpPost] [ActionName("CrearTipoArchivo")]
        public async Task<bool> CreateFileTypeAsync([FromBody] TipoArchivo tipoArchivo) {
            return await descargas.CrearTipoArchivo(tipoArchivo);
        }

        //GET: https://localhost:5001/Api/Descargas/GetTiposArchivo
        [HttpGet] [ActionName("GetTiposArchivo")]
        public async Task<List<TipoArchivo>> GetFileTypesAsync() {
            return await descargas.GetTiposArchivo();
        }

        //PUT: https://localhost:5001/Api/Descargas/ActualizarTipoArchivo
        [HttpPut] [ActionName("ActualizarTipoArchivo")]
        public async Task<bool> UpdateFileTypeAsync([FromBody] TipoArchivo tipoArchivo) {
            return await descargas.ActualizarTipoArchivo(tipoArchivo);
        }

        //DELETE: https://localhost:5001/Api/Descargas/EliminarTipoArchivo?id_tipo_archivo=[value]
        [HttpDelete] [ActionName("EliminarTipoArchivo")]
        public async Task<bool> DeleteFileTypeAsync(int id_tipo_archivo) {
            return await descargas.EliminarTipoArchivo(id_tipo_archivo);
        }
    }
}