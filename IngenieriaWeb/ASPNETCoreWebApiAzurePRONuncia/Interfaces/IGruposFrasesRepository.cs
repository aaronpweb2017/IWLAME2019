using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiAzurePRONuncia.Models;


namespace ASPNETCoreWebApiAzurePRONuncia 
{
    public interface IGruposFrasesRepository 
    {
        Task<List<GrupoFrase>> GetGrupos();
        Task<GrupoFrase> GetGrupo(string partitionKey, string rowKey);
        Task<bool> CrearGrupo(GrupoFrase grupo);
        Task<bool> BorrarGrupo(string partitionKey, string rowKey);
    }
}