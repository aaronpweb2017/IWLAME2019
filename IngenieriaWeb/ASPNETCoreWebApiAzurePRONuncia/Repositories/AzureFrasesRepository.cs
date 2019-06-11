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
    public class AzureFrasesRepository : IFrasesRepository 
    {
        private readonly string AzureConnectionString;
        private CloudTable cloudTableJU, cloudTableGF, cloudTableFR;
        public AzureFrasesRepository(string AzuTabConnStr) {
            AzureConnectionString = AzuTabConnStr;
            CloudStorageAccount StorageAcount = CloudStorageAccount.Parse(AzuTabConnStr);
            CloudTableClient TableClient = StorageAcount.CreateCloudTableClient();
            cloudTableGF = TableClient.GetTableReference("GrupoFrase");
            cloudTableFR = TableClient.GetTableReference("Frase");
            cloudTableJU = TableClient.GetTableReference("Jugador");
        }
        
        public async Task<List<Frase>> GetFrases() {
            List<Frase> ListaFrases = new List<Frase>();
            TableQuery<FraseEntity> tableQuery = new TableQuery<FraseEntity>();
            TableContinuationToken ContinuationToken = new TableContinuationToken();
            foreach(FraseEntity fraseentity in await cloudTableFR.ExecuteQuerySegmentedAsync(tableQuery, ContinuationToken)) 
                ListaFrases.Add(new Frase() {
                    email_jugador = fraseentity.PartitionKey,
                    nombre_grupo = fraseentity.RowKey,
                    valor_frase = fraseentity.valor_frase
                });
            return ListaFrases;
        }

        public async Task<Frase> GetFrase(string partitionKey, string rowKey, int no_frase) {
            Frase frase = new Frase(); int NoFraseGrupo; 
            TableQuery<FraseEntity> tableQuery = new TableQuery<FraseEntity>();
            TableContinuationToken ContinuationToken = new TableContinuationToken();
            foreach(FraseEntity fraseentity in await cloudTableFR.ExecuteQuerySegmentedAsync(tableQuery, ContinuationToken)) {
                NoFraseGrupo = GetGroupPhraseNumberByRowKey(fraseentity.RowKey);
                if(fraseentity.PartitionKey.Equals(partitionKey) && GetGroupNameByRowKey(fraseentity.RowKey).Equals(rowKey) && NoFraseGrupo==no_frase) {
                    frase.email_jugador = fraseentity.PartitionKey; frase.nombre_grupo = fraseentity.RowKey; frase.valor_frase = fraseentity.valor_frase; break;
                }
            }
            return frase;
        }

        public async Task<bool> CrearFrase(Frase frase) {
            bool response = false; int NoFrasesGrupo = 0, NoDigitosAnterior = 0;
            int NoDigitosActual = 0, diferenciaNoDigits = 0;
            try {
                NoFrasesGrupo = GetGroupPhrasesNumberByRowKey(frase.email_jugador, frase.nombre_grupo).Result;
                NoDigitosAnterior = NoFrasesGrupo.ToString().Length;
                if(NoFrasesGrupo == 0) { NoFrasesGrupo = 1; } else { NoFrasesGrupo = NoFrasesGrupo+1; };
                FraseEntity fraseEntity = new FraseEntity(frase.email_jugador, frase.nombre_grupo+"."+NoFrasesGrupo);
                fraseEntity.valor_frase = frase.valor_frase;
                TableOperation insertOperation = TableOperation.Insert(fraseEntity);
                await cloudTableFR.ExecuteAsync(insertOperation);
                NoDigitosActual = NoFrasesGrupo.ToString().Length;
                diferenciaNoDigits = NoDigitosActual - NoDigitosAnterior;
                if(diferenciaNoDigits == 1)
                    AjustaFrasesRowKey(frase.email_jugador, frase.nombre_grupo);
                response = true;
            }
            catch(Exception exception) {
                await Console.Out.WriteLineAsync(exception.Message);
                response = false;
            }
            return response;
        }

        public async Task<bool> ActualizarFrase(string partitionKey, string rowKey, int no_frase, string valor_frase) {
            bool response = false; int NoFraseGrupo;
            TableQuery<FraseEntity> tableQuery = new TableQuery<FraseEntity>();
            TableContinuationToken ContinuationToken = new TableContinuationToken();
            foreach(FraseEntity fraseentity in await cloudTableFR.ExecuteQuerySegmentedAsync(tableQuery, ContinuationToken)) {
                NoFraseGrupo = GetGroupPhraseNumberByRowKey(fraseentity.RowKey);
                if(fraseentity.PartitionKey.Equals(partitionKey) && GetGroupNameByRowKey(fraseentity.RowKey).Equals(rowKey) && NoFraseGrupo == no_frase) {
                    TableOperation RetrieveOperation = TableOperation.Retrieve<FraseEntity>(partitionKey, fraseentity.RowKey);
                    TableResult RetrievedResult = await cloudTableFR.ExecuteAsync(RetrieveOperation);
                    FraseEntity EntityToUpdate = (FraseEntity) RetrievedResult.Result;
                    TableOperation UpdateOperation = TableOperation.Replace(EntityToUpdate);
                    await cloudTableFR.ExecuteAsync(UpdateOperation);
                    response = true; break;
                }
            }
            return response;
        }

        public async Task<bool> BorrarFrase(string partitionKey, string rowKey, int no_frase) {
            bool response = false; int NoFraseGrupo, NoFrasesGrupo;
            int NoDigitosAnterior = 0, NoDigitosActual = 0, diferenciaNoDigits = 0;
            TableQuery<FraseEntity> tableQuery = new TableQuery<FraseEntity>();
            TableContinuationToken ContinuationToken = new TableContinuationToken();
            foreach(FraseEntity fraseentity in await cloudTableFR.ExecuteQuerySegmentedAsync(tableQuery, ContinuationToken)) {
                NoFraseGrupo = GetGroupPhraseNumberByRowKey(fraseentity.RowKey);
                if(fraseentity.PartitionKey.Equals(partitionKey) && GetGroupNameByRowKey(fraseentity.RowKey).Equals(rowKey) && NoFraseGrupo == no_frase) {
                    TableOperation RetrieveOperation = TableOperation.Retrieve<FraseEntity>(fraseentity.PartitionKey, fraseentity.RowKey);
                    TableResult RetrievedResult = await cloudTableFR.ExecuteAsync(RetrieveOperation);
                    FraseEntity EntityToDelete = (FraseEntity) RetrievedResult.Result;
                    TableOperation DeleteOperation = TableOperation.Delete(EntityToDelete);
                    await cloudTableFR.ExecuteAsync(DeleteOperation);
                    NoFrasesGrupo = GetGroupPhrasesNumberByRowKey(partitionKey, rowKey).Result;
                    NoDigitosAnterior = NoFrasesGrupo.ToString().Length;
                    NoDigitosActual = (NoFrasesGrupo-1).ToString().Length;
                    diferenciaNoDigits = NoDigitosAnterior - NoDigitosActual;
                    if(diferenciaNoDigits == 1)
                        AjustaFrasesRowKey(partitionKey, rowKey);
                    response = true; break;
                }
            }
            return response;
        }

        public async void AjustaFrasesRowKey(string partitionKey, string rowKey) {
            List<Frase> ListaFrases = GetFrasesGrupoJugador(partitionKey, rowKey).Result;
            string NombreGrupo; int NoFrase = 1; int NoFrases = ListaFrases.Count;
            int zeroCounter = Convert.ToString(NoFrases).Length - Convert.ToString(NoFrase).Length;
            for(int i = 0; i < NoFrases; i++) {
                for (int j = 9; j <= i; j=(j+1)*10-1) 
                    if (j == i) zeroCounter = zeroCounter - 1;
                NombreGrupo = rowKey+"."+getNZeros(zeroCounter)+NoFrase;
                TableOperation RetrieveOperation = TableOperation.Retrieve<FraseEntity>(partitionKey, ListaFrases[i].nombre_grupo);
                TableResult RetrievedResult = await cloudTableFR.ExecuteAsync(RetrieveOperation);
                FraseEntity EntityToDelete = (FraseEntity) RetrievedResult.Result;
                TableOperation DeleteOperation = TableOperation.Delete(EntityToDelete);
                await cloudTableFR.ExecuteAsync(DeleteOperation);
                FraseEntity EntityToCreate = new FraseEntity(partitionKey, NombreGrupo);
                EntityToCreate.valor_frase = ListaFrases[i].valor_frase;
                TableOperation InsertOperation = TableOperation.Insert(EntityToCreate);
                await cloudTableFR.ExecuteAsync(InsertOperation); NoFrase++;
            }
        }

        //public async Task<bool> ExisteJugadorEnGrupos(string partitionKey, string rowKey) {
        //    bool foundplayer = false;
        //    TableQuery<GrupoFraseEntity> tableQuery = new TableQuery<GrupoFraseEntity>();
        //    TableContinuationToken ContinuationToken = new TableContinuationToken();
        //    foreach(GrupoFraseEntity grupoentity in await cloudTableGF.ExecuteQuerySegmentedAsync(tableQuery, ContinuationToken))  {
        //        if(grupoentity.PartitionKey.Equals(partitionKey) && grupoentity.RowKey.Equals(rowKey)) { foundplayer = true; break; }
        //    }
        //    return foundplayer;
        //}

        public int GetGroupPhraseNumberByRowKey(string RowKey) {
            string PhraseNumberStr = ""; int PhraseNumberInt = 0;
            char [] groupNameCharacters = RowKey.ToCharArray();
            for(int i = 0; i < groupNameCharacters.Length; i++) {
                if(groupNameCharacters[i].Equals('.')) {
                    for(int j = (i+1); j < groupNameCharacters.Length; j++) {
                        PhraseNumberStr += groupNameCharacters[j];
                    } break;
                }
            }
            PhraseNumberInt = Convert.ToInt16(PhraseNumberStr);
            return PhraseNumberInt;
        }

        public async Task<int> GetGroupPhrasesNumberByRowKey(string partitionKey, string rowKey) {
            TableQuery<FraseEntity> tableQuery = new TableQuery<FraseEntity>();
            TableContinuationToken ContinuationToken = new TableContinuationToken(); int NoPhrases = 0;
            foreach(FraseEntity fraseentity in await cloudTableFR.ExecuteQuerySegmentedAsync(tableQuery, ContinuationToken)) {
                if(fraseentity.PartitionKey.Equals(partitionKey) && GetGroupNameByRowKey(fraseentity.RowKey).Equals(rowKey)) NoPhrases++;
            }
            return NoPhrases;
        }

        public string GetGroupNameByRowKey(string RowKey) {
            string GroupName = ""; char [] groupNameCharacters; 
            groupNameCharacters = RowKey.ToCharArray();
            for(int i = 0; i < groupNameCharacters.Length; i++) {
                if(groupNameCharacters[i].Equals('.')) break;
                GroupName += groupNameCharacters[i]; continue;
            }
            return GroupName;
        }

        public async Task<List<Frase>> GetFrasesGrupoJugador(string partitionKey, string nombre_grupo) {
            List<Frase> ListaFrases = new List<Frase>(); string NombreGrupo;
            TableQuery<FraseEntity> tableQuery = new TableQuery<FraseEntity>();
            TableContinuationToken ContinuationToken = new TableContinuationToken();
            foreach(FraseEntity fraseentity in await cloudTableFR.ExecuteQuerySegmentedAsync(tableQuery, ContinuationToken)) {
                if(fraseentity.PartitionKey == partitionKey) {
                    NombreGrupo = GetGroupNameByRowKey(fraseentity.RowKey);
                    if(NombreGrupo.Equals(nombre_grupo)) {
                            ListaFrases.Add(new Frase() {
                                email_jugador = fraseentity.PartitionKey,
                                nombre_grupo = fraseentity.RowKey,
                                valor_frase = fraseentity.valor_frase
                        });
                    }
                }
            }
            return ListaFrases;
        }

        public string getNZeros(int n) {
            String zeros = "";
            for (int i = 0; i < n; i++)
                zeros += "0";
            return zeros;
        }
    }
}