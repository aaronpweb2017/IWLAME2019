using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiAzurePRONuncia.Models;


namespace ASPNETCoreWebApiAzurePRONuncia 
{
    public interface IFrasesRepository 
    {
        Task<List<Frase>> GetFrases();
        Task<Frase> GetFrase(string partitionKey, string rowKey, int no_frase);
        Task<bool> CrearFrase(Frase frase);
        Task<bool> ActualizarFrase(string partitionKey, string rowKey, int no_frase, string valor_frase);
        Task<bool> BorrarFrase(string partitionKey, string rowKey, int no_frase);
    }
}