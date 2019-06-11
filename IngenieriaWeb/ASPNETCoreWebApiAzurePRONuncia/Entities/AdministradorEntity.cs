using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using ASPNETCoreWebApiAzurePRONuncia.Models;

namespace ASPNETCoreWebApiAzurePRONuncia 
{
    public class AdministradorEntity : TableEntity
    {   
        public string password { get; set; }
        public AdministradorEntity() { }

        public AdministradorEntity(string partitionKey, string rowKey) {
            this.PartitionKey = partitionKey; this.RowKey = rowKey;
        }
    }
}