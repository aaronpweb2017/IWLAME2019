using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreWebApiAzurePRONuncia.Models;

namespace ASPNETCoreWebApiAzurePRONuncia.Controllers
{
    [Route("Api/[controller]/[action]")] [ApiController]
    public class AdministradoresController : ControllerBase
    {
        private readonly IAdministradoresRepository AdministradoresRepository;

        public AdministradoresController(IAdministradoresRepository AdministradoresRepository) {
            this.AdministradoresRepository = AdministradoresRepository;
        }
        
        //GET: https://localhost:5001/Api/Administradores/GetAdministradores
        [HttpGet] [ActionName("GetAdministradores")]
        public Task<List<Administrador>> GetAdmins() {
            return AdministradoresRepository.GetAdministradores();
        }

        //GET: https://localhost:5001/Api/Administradores/GetAdministrador?email=[value]
        [HttpGet] [ActionName("GetAdministrador")]
        public Task<Administrador> GetAdmin(string email) {
            return AdministradoresRepository.GetAdministrador(email);
        }

        //POST: https://localhost:5001/Api/Administradores/CrearAdministrador
        [HttpPost] [ActionName("CrearAdministrador")]
        public Task<bool> CreateAdmin([FromBody] Administrador administrador) {
            return AdministradoresRepository.CrearAdministrador(administrador);
        }

        //GET: https://localhost:5001/Api/Administradores/GetFrasesGlobalesAdministrador/?email=[value]
        [HttpGet] [ActionName("GetFrasesGlobalesAdministrador")]
        public Task<List<FraseGlobal>> GetAllAdminGlobalPhrases(string email) {
            return AdministradoresRepository.GetFrasesGlobalesAdministrador(email);
        }
    }
}