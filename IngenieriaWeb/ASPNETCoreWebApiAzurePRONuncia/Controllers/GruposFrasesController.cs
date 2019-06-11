using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreWebApiAzurePRONuncia.Models;

namespace ASPNETCoreWebApiAzurePRONuncia.Controllers 
{
    [Route("Api/[controller]/[action]")] [ApiController]  
    public class GruposFrasesController : ControllerBase 
    {
        private readonly IGruposFrasesRepository GruposFrasesRepository;
        public GruposFrasesController(IGruposFrasesRepository GruposFrasesRepository) {
            this.GruposFrasesRepository = GruposFrasesRepository;
        }

        //GET: https://localhost:5001/Api/GruposFrases/GetGrupos
        [HttpGet] [ActionName("GetGrupos")]
        public Task<List<GrupoFrase>> GetAllGroups() {
            return GruposFrasesRepository.GetGrupos();
        }

        //GET: https://localhost:5001/Api/GruposFrases/GetGrupo/?email=[value]&nombre_grupo=[value]
        [HttpGet] [ActionName("GetGrupo")]
        public Task<GrupoFrase> GetGroup(string email, string nombre_grupo) {
            return GruposFrasesRepository.GetGrupo(email, nombre_grupo);
        }

        //POST: https://localhost:5001/Api/GruposFrases/CrearGrupo
        [HttpPost] [ActionName("CrearGrupo")]
        public Task<bool> CreateGroup([FromBody] GrupoFrase grupo) {
            return GruposFrasesRepository.CrearGrupo(grupo);
        }

        //DELETE: https://localhost:5001/Api/GruposFrases/BorrarGrupo/?email=[value]&nombre_grupo=[value]
        [HttpDelete] [ActionName("BorrarGrupo")]
        public Task<bool> DeleteGroup(string email, string nombre_grupo) {
            return GruposFrasesRepository.BorrarGrupo(email, nombre_grupo);
        }
    }
}