using System;
using System.Collections.Generic;
using ASPNETCoreWebApiAzurePRONuncia.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;

namespace ASPNETCoreWebApiAzurePRONuncia 
{
    public class AzureJugadoresRepository : IJugadoresRepository
    {
        private readonly string AzureConnectionString;
        private CloudTable cloudTableJU, cloudTableGF, cloudTableFR;

        public AzureJugadoresRepository(string AzuTabConnStr) {
            AzureConnectionString = AzuTabConnStr;
            CloudStorageAccount StorageAcount = CloudStorageAccount.Parse(AzuTabConnStr);
            CloudTableClient TableClient = StorageAcount.CreateCloudTableClient();
            cloudTableJU = TableClient.GetTableReference("Jugador");
            cloudTableGF = TableClient.GetTableReference("GrupoFrase");
            cloudTableFR = TableClient.GetTableReference("Frase");
        }

        public bool ExisteJugador(string partitionKey) {
            Jugador jugador = GetJugador(partitionKey).Result;
            if(string.IsNullOrEmpty(jugador.email)) { 
                return false;
            }
            return true;
        }

        public async Task<List<Jugador>> GetJugadores() {
            List<Jugador> ListaJugadores = new List<Jugador>();
            TableQuery<JugadorEntity> tableQuery = new TableQuery<JugadorEntity>();
            TableContinuationToken ContinuationToken = new TableContinuationToken();
            foreach(JugadorEntity jugador in await cloudTableJU.ExecuteQuerySegmentedAsync(tableQuery, ContinuationToken)) {
                ListaJugadores.Add(new Jugador() {
                    email = jugador.PartitionKey, username = jugador.RowKey,
                    name = jugador.name, lastname = jugador.lastname,
                    country = jugador.country, level = jugador.level,
                    nopoints = jugador.nopoints, elo = jugador.elo
                });
            }
            return ListaJugadores;
        }

        public async Task<Jugador> GetJugador(string partitionKey) {
            string rowKey = GetRowKeyByPartitionKey(partitionKey).Result;
            Jugador jugador = new Jugador(); if(string.IsNullOrEmpty(rowKey)) { return jugador; }
            TableOperation RetrieveOperation = TableOperation.Retrieve<JugadorEntity>(partitionKey, rowKey);
            TableResult RetrievedResult = await cloudTableJU.ExecuteAsync(RetrieveOperation);
            JugadorEntity EntityToRead = (JugadorEntity) RetrievedResult.Result;
            jugador.email = EntityToRead.PartitionKey; jugador.username = EntityToRead.RowKey;
            jugador.name = EntityToRead.name; jugador.lastname = EntityToRead.lastname;
            jugador.country = EntityToRead.country; jugador.level = EntityToRead.level;
            jugador.nopoints = EntityToRead.nopoints; jugador.elo = EntityToRead.elo;
            return jugador;
        }

        public async Task<bool> CrearJugador(Jugador jugador) {
            bool response = false;
            try {
                JugadorEntity jugadorEntity = new JugadorEntity(jugador.email, jugador.username);
                jugadorEntity.name = jugador.name; jugadorEntity.lastname = jugador.lastname;
                jugadorEntity.country = jugador.country; jugadorEntity.level = jugador.level;
                jugadorEntity.nopoints = jugador.nopoints; jugadorEntity.elo = jugador.elo;
                TableOperation insertOperation = TableOperation.Insert(jugadorEntity);
                await cloudTableJU.ExecuteAsync(insertOperation); response = true;
            }
            catch(Exception exception) {
                Console.ForegroundColor = ConsoleColor.Red;
                await Console.Out.WriteLineAsync("EL JUGADOR YA EXISTE. MSJ: "+exception.Message);
                Console.ForegroundColor = ConsoleColor.Green;
                response = false;
            }
            
            return response;
        }
        
        public async Task<bool> ActualizarJugador(string partitionKey, Jugador jugador) {
            string rowKey = GetRowKeyByPartitionKey(partitionKey).Result;
            bool response = false;
            if(string.IsNullOrEmpty(rowKey)) {
                Console.ForegroundColor = ConsoleColor.Red;
                await Console.Out.WriteLineAsync("EL JUGADOR A MODIFICAR NO EXISTE.");
                Console.ForegroundColor = ConsoleColor.Green; return response; 
            }
            try {
                TableOperation RetrieveOperation = TableOperation.Retrieve<JugadorEntity>(partitionKey, rowKey);
                TableResult RetrievedResult = await cloudTableJU.ExecuteAsync(RetrieveOperation);
                JugadorEntity EntityToUpdate = (JugadorEntity) RetrievedResult.Result;
                EntityToUpdate.name = jugador.name; EntityToUpdate.lastname = jugador.lastname;
                EntityToUpdate.country = jugador.country; EntityToUpdate.level = jugador.level;
                EntityToUpdate.nopoints = jugador.nopoints; EntityToUpdate.elo = jugador.elo;
                TableOperation UpdateOperation = TableOperation.Replace(EntityToUpdate);
                await cloudTableJU.ExecuteAsync(UpdateOperation); response = true; 
            }
            catch(Exception exception) {
                Console.ForegroundColor = ConsoleColor.Red;
                await Console.Out.WriteLineAsync(exception.Message);
                Console.ForegroundColor = ConsoleColor.Green; response = false;
            }
            return response;
        }

        public async Task<bool> BorrarJugador(string partitionKey) {
            string rowKey = GetRowKeyByPartitionKey(partitionKey).Result;
            bool response = false;
            if(string.IsNullOrEmpty(rowKey)) {
                Console.ForegroundColor = ConsoleColor.Red;
                await Console.Out.WriteLineAsync("EL JUGADOR A ELIMINAR NO EXISTE.");
                Console.ForegroundColor = ConsoleColor.Green; return response; 
            }
            TableQuery<GrupoFraseEntity> tableQuery = new TableQuery<GrupoFraseEntity>();
            TableContinuationToken ContinuationToken = new TableContinuationToken();
            foreach(GrupoFraseEntity grupofrase in await cloudTableGF.ExecuteQuerySegmentedAsync(tableQuery, ContinuationToken)) {
                if(grupofrase.PartitionKey.Equals(partitionKey)) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    await Console.Out.WriteLineAsync("NO SE PUEDE ELIMINAR UN JUGADOR ASOCIADO A UN GRUPO.");
                    Console.ForegroundColor = ConsoleColor.Green; return response;
                }
            }
            try {
                TableOperation RetrieveOperation = TableOperation.Retrieve<JugadorEntity>(partitionKey, rowKey);
                TableResult RetrievedResult = await cloudTableJU.ExecuteAsync(RetrieveOperation);
                JugadorEntity EntityToDelete = (JugadorEntity) RetrievedResult.Result;
                TableOperation DeleteOperation = TableOperation.Delete(EntityToDelete);
                await cloudTableJU.ExecuteAsync(DeleteOperation); response = true; 
            }
            catch(Exception exception) {
                Console.ForegroundColor = ConsoleColor.Red;
                await Console.Out.WriteLineAsync(exception.Message);
                Console.ForegroundColor = ConsoleColor.Green;
                response = false;
            }
            return response;
        }

        public async Task<List<GrupoFrase>> GetGruposJugador(string partitionKey) {
            List<GrupoFrase> ListaGrupos = new List<GrupoFrase>();
            TableQuery<GrupoFraseEntity> tableQuery = new TableQuery<GrupoFraseEntity>();
            TableContinuationToken ContinuationToken = new TableContinuationToken();
            foreach(GrupoFraseEntity grupofrase in await cloudTableGF.ExecuteQuerySegmentedAsync(tableQuery, ContinuationToken)) {
                if(grupofrase.PartitionKey == partitionKey) {
                    ListaGrupos.Add(new GrupoFrase() {
                        email_jugador = grupofrase.PartitionKey,
                        nombre_grupo = grupofrase.RowKey
                    });
                }
            }
            return ListaGrupos;
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

        public List<Frase> GetFrasesGruposJugador(string partitionKey) {
            List<GrupoFrase> ListaGrupos = GetGruposJugador(partitionKey).Result;
            List<Frase> ListaFrasesGrupo = new List<Frase>();
            List<Frase> ListaFrasesGrupos = new List<Frase>();
            foreach(GrupoFrase grupofrase in ListaGrupos) {
                ListaFrasesGrupo = GetFrasesGrupoJugador(partitionKey, grupofrase.nombre_grupo).Result;
                foreach(Frase frase in ListaFrasesGrupo) ListaFrasesGrupos.Add(frase);
            }
             return ListaFrasesGrupos;
        }

        public async Task<string> GetRowKeyByPartitionKey(string partitionKey) {
            TableQuery<JugadorEntity> tableQuery = new TableQuery<JugadorEntity>();
            TableContinuationToken ContinuationToken = new TableContinuationToken(); string rowKey = "";
            foreach(JugadorEntity jugadorentity in await cloudTableJU.ExecuteQuerySegmentedAsync(tableQuery, ContinuationToken)) {
                if(jugadorentity.PartitionKey == partitionKey) { rowKey = jugadorentity.RowKey; break; }
            }
            return rowKey;
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
    }
}