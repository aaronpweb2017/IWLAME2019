using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using ASPNETCoreWebApiAzurePRONuncia.Models;

namespace ASPNETCoreWebApiAzurePRONuncia 
{
    public class JugadorEntity : TableEntity
    {   
        public string name { get; set; }
        public string lastname { get; set; }
        public string country { get; set; }
        public int level { get; set; }
        public int nopoints { get; set; }
        public int elo { get; set; }
        
        public JugadorEntity() { }

        public JugadorEntity(string partitionKey, string rowKey) {
            this.PartitionKey = partitionKey; this.RowKey = rowKey;
        }
    }
}