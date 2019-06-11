using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreWebApiAzurePRONuncia.Models;

namespace ASPNETCoreWebApiAzurePRONuncia.Controllers 
{
    [Route("Api/[controller]/[action]")] [ApiController]  
    public class FrasesGlobalesController : ControllerBase 
    {
        private readonly IFrasesGlobalesRepository FrasesGlobalesRepository;
        public FrasesGlobalesController(IFrasesGlobalesRepository FrasesGlobalesRepository) {
            this.FrasesGlobalesRepository = FrasesGlobalesRepository;
        }

        //POST: https://localhost:5001/Api/FrasesGlobales/CrearFraseGlobal
        [HttpPost] [ActionName("CrearFraseGlobal")]
        public Task<bool> CreateGlobalPhrase([FromBody] FraseGlobal fraseGlobal) {
            return FrasesGlobalesRepository.CrearFraseGlobal(fraseGlobal);
        }

        //PUT: https://localhost:5001/Api/FrasesGlobales/ActualizarFraseGlobal/?email=[value]&no_frase[value]&valor_frase=[value]
        [HttpPut] [ActionName("ActualizarFraseGlobal")]
        public Task<bool> ModifyGlobalPhrase(string email, int no_frase, string valor_frase) {
            return FrasesGlobalesRepository.ActualizarFraseGlobal(email, no_frase, valor_frase);
        }

        //DELETE: https://localhost:5001/Api/FrasesGlobales/BorrarFraseGlobal/?email=[value]&no_frase[value]
        [HttpDelete] [ActionName("BorrarFraseGlobal")]
        public Task<bool> DeleteGlobalPhrase(string email, int no_frase) {
            return FrasesGlobalesRepository.BorrarFraseGlobal(email, no_frase);
        }

        //POST: https://localhost:5001/Api/FrasesGlobales/InsertaFrasesGlobales
        //[HttpPost] [ActionName("InsertaFrasesGlobales")]
        //public bool InsertGlobalPhrase() {
        //    return FrasesGlobalesRepository.InsertaFrasesGlobales();
        //}
    }
}