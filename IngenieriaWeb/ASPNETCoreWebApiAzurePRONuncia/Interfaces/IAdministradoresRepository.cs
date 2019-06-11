using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiAzurePRONuncia.Models;

namespace ASPNETCoreWebApiAzurePRONuncia 
{
    public interface IAdministradoresRepository
    {
        Task<List<Administrador>> GetAdministradores();
        Task<Administrador> GetAdministrador(string partitionKey);
        Task<bool> CrearAdministrador(Administrador administrador);
        Task<List<FraseGlobal>> GetFrasesGlobalesAdministrador(string partitionKey);
    } 
}