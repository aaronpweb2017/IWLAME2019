using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiAzurePRONuncia.Models;

namespace ASPNETCoreWebApiAzurePRONuncia 
{
    public interface IJugadoresRepository
    {
        bool ExisteJugador(string partitionKey);
        Task<List<Jugador>> GetJugadores();
        Task<Jugador> GetJugador(string partitionKey);
        Task<bool> CrearJugador(Jugador jugador);
        Task<bool> ActualizarJugador(string partitionKey, Jugador jugador);
        Task<bool> BorrarJugador(string partitionKey);
        Task<List<GrupoFrase>> GetGruposJugador(string partitionKey);
        Task<List<Frase>> GetFrasesGrupoJugador(string partitionKey, string nombre_grupo);
        List<Frase> GetFrasesGruposJugador(string partitionKey);
        //Task<bool> InsertaFrasesGrupo();
    } 
}