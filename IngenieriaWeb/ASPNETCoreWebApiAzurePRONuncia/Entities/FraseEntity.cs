using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiAzurePRONuncia.Models;

namespace ASPNETCoreWebApiAzurePRONuncia 
{
    public class FraseEntity : TableEntity
    {   
        public string valor_frase { get; set; }
        public FraseEntity() { }

        public FraseEntity(string partitionKey, string rowKey) {
            this.PartitionKey = partitionKey; this.RowKey = rowKey;
        }
    }
}