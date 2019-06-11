using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiAzurePRONuncia.Models;

namespace ASPNETCoreWebApiAzurePRONuncia
{
    public interface IFrasesGlobalesRepository
    {
        Task<bool> CrearFraseGlobal(FraseGlobal fraseGlobal);
        Task<bool> ActualizarFraseGlobal(string partitionKey, int no_frase, string valor_frase);
        Task<bool> BorrarFraseGlobal(string partitionKey, int no_frase);
        //bool InsertaFrasesGlobales();
    }
}