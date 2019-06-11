using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreWebApiAzurePRONuncia.Models;

namespace ASPNETCoreWebApiAzurePRONuncia.Controllers 
{
    [Route("Api/[controller]/[action]")] [ApiController]  
    public class FrasesController : ControllerBase 
    {
        private readonly IFrasesRepository FrasesRepository;
        public FrasesController(IFrasesRepository FrasesRepository) {
            this.FrasesRepository = FrasesRepository;
        }

        //GET: https://localhost:5001/Api/Frases/GetFrases
        [HttpGet] [ActionName("GetFrases")]
        public Task<List<Frase>> GetAllPhrases() {
            return FrasesRepository.GetFrases();
        }

        //GET: https://localhost:5001/Api/Frases/GetFrase/?email=[value]&nombre_grupo=[value]&no_frase=[value]
        [HttpGet] [ActionName("GetFrase")]
        public Task<Frase> GetPhrase(string email, string nombre_grupo, int no_frase) {
            return FrasesRepository.GetFrase(email, nombre_grupo, no_frase);
        }

        //POST: https://localhost:5001/Api/Frases/CrearFrase
        [HttpPost] [ActionName("CrearFrase")]
        public Task<bool> CreatePhrase([FromBody] Frase frase) {
            return FrasesRepository.CrearFrase(frase);
        }

        //PUT: https://localhost:5001/Api/Frases/ActualizarFrase/?email=[value]&nombre_grupo=[value]&no_frase=[value]&valor_frase=[value]
        [HttpPut] [ActionName("ActualizarFrase")]
        public Task<bool> ModifyPhrase(string email, string nombre_grupo, int no_frase, string valor_frase) {
            return FrasesRepository.ActualizarFrase(email, nombre_grupo, no_frase, valor_frase);
        }

        //DELETE: https://localhost:5001/Api/Frases/BorrarFrase/?email=[value]&nombre_grupo=[value]&no_frase=[value]
        [HttpDelete] [ActionName("BorrarFrase")]
        public Task<bool> DeletePhrase(string email, string nombre_grupo, int no_frase) {
            return FrasesRepository.BorrarFrase(email, nombre_grupo, no_frase);
        }
    }
}