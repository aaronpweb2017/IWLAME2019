using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<Object []> CreateFileTypeAsync([FromBody] TipoArchivo tipoArchivo) {
            return await descargas.CrearTipoArchivo(tipoArchivo);
        }

        //GET: https://localhost:5001/Api/Descargas/GetTiposArchivo
        [HttpGet] [ActionName("GetTiposArchivo")]
        public async Task<Object []> GetFileTypesAsync() {
            return await descargas.GetTiposArchivo();
        }

        //PUT: https://localhost:5001/Api/Descargas/ActualizarTipoArchivo
        [HttpPut] [ActionName("ActualizarTipoArchivo")]
        public async Task<Object []> UpdateFileTypeAsync([FromBody] TipoArchivo tipoArchivo) {
            return await descargas.ActualizarTipoArchivo(tipoArchivo);
        }

        //DELETE: https://localhost:5001/Api/Descargas/EliminarTipoArchivo?id_tipo_archivo=[value]
        [HttpDelete] [ActionName("EliminarTipoArchivo")]
        public async Task<Object []> DeleteFileTypeAsync(int id_tipo_archivo) {
            return await descargas.EliminarTipoArchivo(id_tipo_archivo);
        }

        //POST: https://localhost:5001/Api/Descargas/CrearServidor
        [HttpPost] [ActionName("CrearServidor")]
        public async Task<Object []> CreateServerAsync([FromBody] Servidor servidor) {
            return await descargas.CrearServidor(servidor);
        }

        //GET: https://localhost:5001/Api/Descargas/GetServidores
        [HttpGet] [ActionName("GetServidores")]
        public async Task<Object []> GetServersAsync() {
            return await descargas.GetServidores();
        }

        //PUT: https://localhost:5001/Api/Descargas/ActualizarServidor
        [HttpPut] [ActionName("ActualizarServidor")]
        public async Task<Object []> UpdateServerAsync([FromBody] Servidor servidor) {
            return await descargas.ActualizarServidor(servidor);
        }

        //DELETE: https://localhost:5001/Api/Descargas/EliminarServidor?id_servidor=[value]
        [HttpDelete] [ActionName("EliminarServidor")]
        public async Task<Object []> DeleteServerAsync(int id_servidor) {
            return await descargas.EliminarServidor(id_servidor);
        }

         //POST: https://localhost:5001/Api/Descargas/CrearDescarga
        [HttpPost] [ActionName("CrearDescarga")]
        public async Task<Object []> CreateDownloadAsync([FromBody] Descarga descarga) {
            return await descargas.CrearDescarga(descarga);
        }

        //GET: https://localhost:5001/Api/Descargas/GetDescargas
        [HttpGet] [ActionName("GetDescargas")]
        public async Task<Object []> GetDownloadsAsync() {
            return await descargas.GetDescargas();
        }

        //PUT: https://localhost:5001/Api/Descargas/ActualizarDescarga
        [HttpPut] [ActionName("ActualizarDescarga")]
        public async Task<Object []> UpdateDownloadAsync([FromBody] Descarga descarga) {
            return await descargas.ActualizarDescarga(descarga);
        }
        
        //DELETE: https://localhost:5001/Api/Descargas/EliminarDescarga?id_descarga=[value]
        [HttpDelete] [ActionName("EliminarDescarga")]
        public async Task<Object []> DeleteDownloadAsync(int id_descarga) {
            return await descargas.EliminarDescarga(id_descarga);
        }

        //POST: https://localhost:5001/Api/Descargas/CrearEnlace
        [HttpPost] [ActionName("CrearEnlace")]
        public async Task<Object []> CreateLinkAsync([FromBody] Enlace enlace) {
            return await descargas.CrearEnlace(enlace);
        }

        //GET: https://localhost:5001/Api/Descargas/GetEnlacesDescarga?id_descarga=[value]
        [HttpGet] [ActionName("GetEnlacesDescarga")]
        public async Task<Object []> GetDownloadLinksAsync(int id_descarga) {
           return await descargas.GetEnlacesDescarga(id_descarga);
        }

        //PUT: https://localhost:5001/Api/Descargas/ActualizarEnlace
        [HttpPut] [ActionName("ActualizarEnlace")]
        public async Task<Object []> UpdateLinkAsync([FromBody] Enlace enlace) {
            return await descargas.ActualizarEnlace(enlace);
        }

        //DELETE: https://localhost:5001/Api/Descargas/EliminarEnlace?id_enlace=[value]
        [HttpDelete] [ActionName("EliminarEnlace")]
        public async Task<Object []> DeleteLinkAsync(int id_enlace) {
            return await descargas.EliminarEnlace(id_enlace);
        }
    }
}