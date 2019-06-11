using System;
using System.Collections.Generic;
using ASPNETCoreWebApiAzurePRONuncia.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace ASPNETCoreWebApiAzurePRONuncia 
{
    public class AzureAdministradoresRepository : IAdministradoresRepository
    {
        private readonly string AzureConnectionString;
        private CloudTable cloudTableAD, cloudTableFG;

        public AzureAdministradoresRepository(string AzuTabConnStr) {
            AzureConnectionString = AzuTabConnStr;
            CloudStorageAccount StorageAcount = CloudStorageAccount.Parse(AzuTabConnStr);
            CloudTableClient TableClient = StorageAcount.CreateCloudTableClient();
            cloudTableAD = TableClient.GetTableReference("Administrador");
            cloudTableFG = TableClient.GetTableReference("FraseGlobal");
        }

        public async Task<List<Administrador>> GetAdministradores() {
            List<Administrador> ListaAdministradores = new List<Administrador>();
            TableQuery<AdministradorEntity> tableQuery = new TableQuery<AdministradorEntity>();
            TableContinuationToken ContinuationToken = new TableContinuationToken();
            foreach(AdministradorEntity administradorEntity in await cloudTableAD.ExecuteQuerySegmentedAsync(tableQuery, ContinuationToken)) {
                ListaAdministradores.Add(new Administrador() {
                    email = administradorEntity.PartitionKey, 
                    username = administradorEntity.RowKey,
                    password = administradorEntity.password
                });
            }
            return ListaAdministradores;
        }

        public async Task<Administrador> GetAdministrador(string partitionKey) {
            string rowKey = GetRowKeyByPartitionKey(partitionKey).Result;
            Administrador administrador = new Administrador(); if(string.IsNullOrEmpty(rowKey)) { return administrador; }
            TableOperation RetrieveOperation = TableOperation.Retrieve<AdministradorEntity>(partitionKey, rowKey);
            TableResult RetrievedResult = await cloudTableAD.ExecuteAsync(RetrieveOperation);
            AdministradorEntity EntityToRead = (AdministradorEntity) RetrievedResult.Result;
            administrador.email = EntityToRead.PartitionKey; administrador.username = EntityToRead.RowKey;
            administrador.password = EntityToRead.password; return administrador;
        }

        public async Task<bool> CrearAdministrador(Administrador administrador) {
            bool response = false;
            try {
                AdministradorEntity administradorEntity = new AdministradorEntity(administrador.email, administrador.username);
                administradorEntity.password = EncryptPassword(administrador.password);
                TableOperation insertOperation = TableOperation.Insert(administradorEntity);
                await cloudTableAD.ExecuteAsync(insertOperation); response = true;
            }
            catch(Exception exception) {
                Console.ForegroundColor = ConsoleColor.Red;
                await Console.Out.WriteLineAsync(exception.Message);
                Console.ForegroundColor = ConsoleColor.Green;
                response = false;
            }
            return response;
        }

        public async Task<List<FraseGlobal>> GetFrasesGlobalesAdministrador(string partitionKey) {
            List<FraseGlobal> ListaFrasesGlobales = new List<FraseGlobal>();
            TableQuery<FraseGlobalEntity> tableQuery = new TableQuery<FraseGlobalEntity>();
            TableContinuationToken ContinuationToken = new TableContinuationToken();
            foreach(FraseGlobalEntity fraseGlobalEntity in await cloudTableFG.ExecuteQuerySegmentedAsync(tableQuery, ContinuationToken)) {
                if(fraseGlobalEntity.PartitionKey == partitionKey) {
                    ListaFrasesGlobales.Add(new FraseGlobal() {
                        email_administrador = fraseGlobalEntity.PartitionKey,
                        nombre_frase = fraseGlobalEntity.RowKey,
                        valor_frase = fraseGlobalEntity.valor_frase
                    });
                }
            }
            return ListaFrasesGlobales;
        }

        public async Task<string> GetRowKeyByPartitionKey(string partitionKey) {
            TableQuery<AdministradorEntity> tableQuery = new TableQuery<AdministradorEntity>();
            TableContinuationToken ContinuationToken = new TableContinuationToken(); string rowKey = "";
            foreach(AdministradorEntity administradorEntity in await cloudTableAD.ExecuteQuerySegmentedAsync(tableQuery, ContinuationToken)) {
                if(administradorEntity.PartitionKey == partitionKey) { rowKey = administradorEntity.RowKey; break; }
            }
            return rowKey;
        }

        public string EncryptPassword(string password) {
            using(MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()) {
                UTF8Encoding utf8e = new UTF8Encoding();
                byte[] data=md5.ComputeHash(utf8e.GetBytes(password));
                return Convert.ToBase64String(data);
            }
        }
    }
}