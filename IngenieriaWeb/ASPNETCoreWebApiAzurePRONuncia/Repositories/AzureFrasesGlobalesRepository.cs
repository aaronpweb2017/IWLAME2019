using System;
using System.Collections.Generic;
using ASPNETCoreWebApiAzurePRONuncia.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace ASPNETCoreWebApiAzurePRONuncia 
{
    public class AzureFrasesGlobalesRepository : IFrasesGlobalesRepository 
    {
        private readonly string AzureConnectionString;
        private CloudTable cloudTableAD, cloudTableFG;

        private string [] frasesGlobales = {"frase1","frase2","frase3","...","frasen"};

        public AzureFrasesGlobalesRepository(string AzuTabConnStr) {
            AzureConnectionString = AzuTabConnStr;
            CloudStorageAccount StorageAcount = CloudStorageAccount.Parse(AzuTabConnStr);
            CloudTableClient TableClient = StorageAcount.CreateCloudTableClient();
            cloudTableAD = TableClient.GetTableReference("Administrador");
            cloudTableFG = TableClient.GetTableReference("FraseGlobal");
        }

        public async Task<bool> CrearFraseGlobal(FraseGlobal fraseGlobal) {
            bool response = false; int NoFrasesAdministrador = 0;
            int NoDigitosAnterior = 0, NoDigitosActual = 0, diferenciaNoDigits = 0;
            try {
                NoFrasesAdministrador = GetAdminPhrasesNumberByPartitionKey(fraseGlobal.email_administrador).Result;
                NoDigitosAnterior = NoFrasesAdministrador.ToString().Length;
                if(NoFrasesAdministrador == 0) { NoFrasesAdministrador = 1; } else { NoFrasesAdministrador+=1; };
                FraseGlobalEntity fraseGlobalEntity = new FraseGlobalEntity(fraseGlobal.email_administrador, "Frase."+NoFrasesAdministrador);
                fraseGlobalEntity.valor_frase = fraseGlobal.valor_frase;
                TableOperation insertOperation = TableOperation.Insert(fraseGlobalEntity);
                await cloudTableFG.ExecuteAsync(insertOperation); 
                NoDigitosActual = NoFrasesAdministrador.ToString().Length;
                diferenciaNoDigits = NoDigitosActual - NoDigitosAnterior;
                if(diferenciaNoDigits == 1) {
                    AjustaFrasesGlobalesRowKey(fraseGlobal.email_administrador);
                }
                response = true;
            }
            catch(Exception exception) {
                await Console.Out.WriteLineAsync(exception.Message);
                response = false;
            }
            return response;
        }

        public async Task<bool> ActualizarFraseGlobal(string partitionKey, int no_frase, string valor_frase) {
            bool response = false; int phrase_number = 0;
            TableQuery<FraseGlobalEntity> tableQuery = new TableQuery<FraseGlobalEntity>();
            TableContinuationToken continuationToken = new TableContinuationToken();
            foreach(FraseGlobalEntity fraseGlobalEntity in await cloudTableFG.ExecuteQuerySegmentedAsync(tableQuery, continuationToken)) {
                phrase_number = GetPhraseNumberByRowKey(fraseGlobalEntity.RowKey);
                if(fraseGlobalEntity.PartitionKey.Equals(partitionKey) && phrase_number == no_frase) {
                    TableOperation RetrieveOperation = TableOperation.Retrieve<FraseGlobalEntity>(partitionKey, fraseGlobalEntity.RowKey);
                    TableResult RetrievedResult = await cloudTableFG.ExecuteAsync(RetrieveOperation);
                    FraseGlobalEntity EntityToUpdate = (FraseGlobalEntity) RetrievedResult.Result;
                    EntityToUpdate.valor_frase = valor_frase; 
                    TableOperation UpdateOperation = TableOperation.Replace(EntityToUpdate);
                    await cloudTableFG.ExecuteAsync(UpdateOperation); 
                    response = true; break;
                }
            }
            return response;
        }

        public async Task<bool> BorrarFraseGlobal(string partitionKey, int no_frase) {
            bool response = false; int phrase_number = 0, NoFrasesAdministrador = 0;
            int NoDigitosAnterior = 0, NoDigitosActual = 0, diferenciaNoDigits = 0;
            TableQuery<FraseGlobalEntity> tableQuery = new TableQuery<FraseGlobalEntity>();
            TableContinuationToken continuationToken = new TableContinuationToken();
            foreach(FraseGlobalEntity fraseGlobalEntity in await cloudTableFG.ExecuteQuerySegmentedAsync(tableQuery, continuationToken)) {
                phrase_number = GetPhraseNumberByRowKey(fraseGlobalEntity.RowKey);
                if(fraseGlobalEntity.PartitionKey.Equals(partitionKey) && phrase_number == no_frase) {
                    TableOperation RetrieveOperation = TableOperation.Retrieve<FraseGlobalEntity>(partitionKey, fraseGlobalEntity.RowKey);
                    TableResult RetrievedResult = await cloudTableFG.ExecuteAsync(RetrieveOperation);
                    FraseGlobalEntity EntityToDelete = (FraseGlobalEntity) RetrievedResult.Result;
                    TableOperation DeleteOperation = TableOperation.Delete(EntityToDelete);
                    await cloudTableFG.ExecuteAsync(DeleteOperation);
                    NoFrasesAdministrador = GetAdminPhrasesNumberByPartitionKey(partitionKey).Result;
                    NoDigitosAnterior = NoFrasesAdministrador.ToString().Length;
                    NoDigitosActual = (NoFrasesAdministrador-1).ToString().Length;
                    diferenciaNoDigits = NoDigitosAnterior - NoDigitosActual;
                    if(diferenciaNoDigits == 1)
                        AjustaFrasesGlobalesRowKey(partitionKey);
                    response = true; break;
                }
            }
            return response;
        }

        public async Task<int> GetAdminPhrasesNumberByPartitionKey(string partitionKey) {
            TableQuery<FraseGlobalEntity> tableQuery = new TableQuery<FraseGlobalEntity>();
            TableContinuationToken continuationToken = new TableContinuationToken(); int NoPhrases = 0;
            foreach(FraseGlobalEntity fraseGlobalEntity in await cloudTableFG.ExecuteQuerySegmentedAsync(tableQuery, continuationToken)) {
                if(fraseGlobalEntity.PartitionKey.Equals(partitionKey)) NoPhrases++;
            }
            return NoPhrases;
        }

        public int GetPhraseNumberByRowKey(string RowKey) {
            string PhraseNumberStr = ""; int PhraseNumberInt = 0;
            char [] phraseNameCharacters = RowKey.ToCharArray();
            for(int i = 0; i < phraseNameCharacters.Length; i++) {
                if(phraseNameCharacters[i].Equals('.')) {
                    for(int j = (i+1); j < phraseNameCharacters.Length; j++) {
                        PhraseNumberStr += phraseNameCharacters[j];
                    } break;
                }
            }
            PhraseNumberInt = Convert.ToInt16(PhraseNumberStr);
            return PhraseNumberInt;
        }

        public async void AjustaFrasesGlobalesRowKey(string partitionKey) {
            List<FraseGlobal> ListaFrasesGlobales = GetFrasesGlobalesAdministrador(partitionKey).Result;
            string rowKeyAjustado; int NoFrase = 1; int NoFrases = ListaFrasesGlobales.Count;
            int zeroCounter = Convert.ToString(NoFrases).Length - Convert.ToString(NoFrase).Length;
            for(int i = 0; i < NoFrases; i++) {
                for (int j = 9; j <= i; j=(j+1)*10-1) 
                    if (j == i) { zeroCounter = zeroCounter - 1; }
                rowKeyAjustado = "Frase."+getNZeros(zeroCounter)+NoFrase;
                TableOperation RetrieveOperation = TableOperation.Retrieve<FraseGlobalEntity>(partitionKey, ListaFrasesGlobales[i].nombre_frase);
                TableResult RetrievedResult = await cloudTableFG.ExecuteAsync(RetrieveOperation);
                FraseGlobalEntity EntityToDelete = (FraseGlobalEntity) RetrievedResult.Result;
                TableOperation DeleteOperation = TableOperation.Delete(EntityToDelete);
                await cloudTableFG.ExecuteAsync(DeleteOperation);
                FraseGlobalEntity EntityToCreate = new FraseGlobalEntity(partitionKey, rowKeyAjustado);
                EntityToCreate.valor_frase = ListaFrasesGlobales[i].valor_frase;
                TableOperation InsertOperation = TableOperation.Insert(EntityToCreate);
                await cloudTableFG.ExecuteAsync(InsertOperation); NoFrase++;
            }
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

        public string getNZeros(int n) {
            String zeros = "";
            for (int i = 0; i < n; i++)
                zeros += "0";
            return zeros;
        }

        //public bool InsertaFrasesGlobales() {
        //    bool response = false;
        //   for(int i = 0; i < frasesGlobales.Length; i++) {
        //       response = CrearFraseGlobal(new FraseGlobal() {
        //           email_administrador = "PROnuncia2019@pronuncia.net",
        //           nombre_frase="",valor_frase=frasesGlobales[i]
        //        }).Result;
        //   }
        //   return response;
        //}
    }
}