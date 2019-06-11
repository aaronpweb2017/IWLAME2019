using System;
using System.Collections.Generic;
using ASPNETCoreWebApiAzurePRONuncia.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;

namespace ASPNETCoreWebApiAzurePRONuncia 
{
    public class AzureGruposFrasesRepository : IGruposFrasesRepository 
    {
        private readonly string AzureConnectionString;
        private CloudTable cloudTableJU, cloudTableGF, cloudTableFR;
        public AzureGruposFrasesRepository(string AzuTabConnStr) {
            AzureConnectionString = AzuTabConnStr;
            CloudStorageAccount StorageAcount = CloudStorageAccount.Parse(AzuTabConnStr);
            CloudTableClient TableClient = StorageAcount.CreateCloudTableClient();
            cloudTableJU = TableClient.GetTableReference("Jugador");
            cloudTableGF = TableClient.GetTableReference("GrupoFrase");
            cloudTableFR = TableClient.GetTableReference("Frase");
        }
        
        public async Task<List<GrupoFrase>> GetGrupos() {
            List<GrupoFrase> ListaGrupos = new List<GrupoFrase>();
            TableQuery<GrupoFraseEntity> tableQuery = new TableQuery<GrupoFraseEntity>();
            TableContinuationToken ContinuationToken = new TableContinuationToken();
            foreach(GrupoFraseEntity grupoentity in await cloudTableGF.ExecuteQuerySegmentedAsync(tableQuery, ContinuationToken)) 
                ListaGrupos.Add(new GrupoFrase() {email_jugador = grupoentity.PartitionKey, nombre_grupo = grupoentity.RowKey});
            return ListaGrupos;
        }

        public async Task<GrupoFrase> GetGrupo(string partitionKey, string rowKey) {
            TableOperation RetrieveOperation = TableOperation.Retrieve<GrupoFraseEntity>(partitionKey, rowKey);
            TableResult RetrievedResult = await cloudTableGF.ExecuteAsync(RetrieveOperation);
            GrupoFraseEntity EntityToRead = (GrupoFraseEntity) RetrievedResult.Result;
            GrupoFrase grupo = new GrupoFrase(); grupo.email_jugador = EntityToRead.PartitionKey;
            grupo.nombre_grupo = EntityToRead.RowKey; return grupo;
        }

        public async Task<bool> CrearGrupo(GrupoFrase grupo) {
            bool response = false, foundplayer = ExisteJugador(grupo.email_jugador).Result;
            if(!foundplayer) {
                Console.ForegroundColor = ConsoleColor.Red;
                await Console.Out.WriteLineAsync("EL JUGAOR NO EXISTE.");
                Console.ForegroundColor = ConsoleColor.Green;
                return response;
            }
            try {
                GrupoFraseEntity grupoEntity = new GrupoFraseEntity(grupo.email_jugador, grupo.nombre_grupo);
                TableOperation insertOperation = TableOperation.Insert(grupoEntity);
                await cloudTableGF.ExecuteAsync(insertOperation); response = true;
            }
            catch(Exception exception) {
                Console.ForegroundColor = ConsoleColor.Red;
                await Console.Out.WriteLineAsync("EL GRUPO YA EXISTE. MSJ: "+exception.Message);
                Console.ForegroundColor = ConsoleColor.Green;
                response = false;
            }
            return response;
        }

        public async Task<bool> BorrarGrupo(string partitionKey, string rowKey) {
            bool response = false; string NombreGrupo;
            TableQuery<FraseEntity> tableQuery = new TableQuery<FraseEntity>();
            TableContinuationToken ContinuationToken = new TableContinuationToken();
            foreach(FraseEntity fraseentity in await cloudTableFR.ExecuteQuerySegmentedAsync(tableQuery, ContinuationToken)) {
                NombreGrupo = GetGroupNameByRowKey(fraseentity.RowKey);
                if(fraseentity.PartitionKey.Equals(partitionKey) && NombreGrupo.Equals(rowKey)) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    await Console.Out.WriteLineAsync("NO SE PUEDE ELIMINAR UN GRUPO ASOCIADO A FRASES.");
                    Console.ForegroundColor = ConsoleColor.Green; return response;
                }
            }
            try {
                TableOperation RetrieveOperation = TableOperation.Retrieve<GrupoFraseEntity>(partitionKey, rowKey);
                TableResult RetrievedResult = await cloudTableGF.ExecuteAsync(RetrieveOperation);
                GrupoFraseEntity EntityToDelete = (GrupoFraseEntity) RetrievedResult.Result;
                TableOperation DeleteOperation = TableOperation.Delete(EntityToDelete);
                await cloudTableGF.ExecuteAsync(DeleteOperation); response = true;
            }
            catch(Exception exception) {
                Console.ForegroundColor = ConsoleColor.Red;
                await Console.Out.WriteLineAsync("EL GRUPO A ELIMINAR NO EXISTE. MSJ: "+exception.Message);
                Console.ForegroundColor = ConsoleColor.Green;
                response = false;
            }
            return response;
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

        public async Task<bool> ExisteJugador(string partitionKey) {
            bool foundplayer = false;
            TableQuery<JugadorEntity> tableQuery = new TableQuery<JugadorEntity>();
            TableContinuationToken ContinuationToken = new TableContinuationToken();
            foreach(JugadorEntity jugadorentity in await cloudTableJU.ExecuteQuerySegmentedAsync(tableQuery, ContinuationToken)) {
                if(jugadorentity.PartitionKey.Equals(partitionKey)) { foundplayer = true; break; }
            }
            return foundplayer;
        }
    }
}