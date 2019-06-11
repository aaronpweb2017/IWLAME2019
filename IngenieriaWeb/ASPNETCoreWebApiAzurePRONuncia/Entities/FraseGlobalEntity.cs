using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using ASPNETCoreWebApiAzurePRONuncia.Models;

namespace ASPNETCoreWebApiAzurePRONuncia 
{
    public class FraseGlobalEntity : TableEntity
    {   
        public string valor_frase { get; set; }
        public FraseGlobalEntity() { }

        public FraseGlobalEntity(string partitionKey, string rowKey) {
            this.PartitionKey = partitionKey; this.RowKey = rowKey;
        }
    }
}