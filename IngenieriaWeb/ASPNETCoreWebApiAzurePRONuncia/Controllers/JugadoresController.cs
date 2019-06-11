using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreWebApiAzurePRONuncia.Models;

namespace ASPNETCoreWebApiAzurePRONuncia.Controllers
{
    [Route("Api/[controller]/[action]")] [ApiController]
    public class JugadoresController : ControllerBase
    {
        private readonly IJugadoresRepository JugadoresRepository;

        public JugadoresController(IJugadoresRepository JugadoresRepository) {
            this.JugadoresRepository = JugadoresRepository;
        }

        //GET: https://localhost:5001/Api/Jugadores/ExisteJugador?email=[value]
        [HttpGet] [ActionName("ExisteJugador")]
        public bool ExistPlayer(string email) {
            return JugadoresRepository.ExisteJugador(email);
        }
        
        //GET: https://localhost:5001/Api/Jugadores/GetJugadores
        [HttpGet] [ActionName("GetJugadores")]
        public Task<List<Jugador>> GetPlayers() {
            return JugadoresRepository.GetJugadores();
        }

        //GET: https://localhost:5001/Api/Jugadores/GetJugador?email=[value]
        [HttpGet] [ActionName("GetJugador")]
        public Task<Jugador> GetPlayer(string email) {
            return JugadoresRepository.GetJugador(email);
        }

        //POST: https://localhost:5001/Api/Jugadores/CrearJugador
        [HttpPost] [ActionName("CrearJugador")]
        public Task<bool> CreatePlayer([FromBody] Jugador jugador) {
            return JugadoresRepository.CrearJugador(jugador);
        }

        //PUT: https://localhost:5001/Api/Jugadores/ActualizarJugador/?email=[value]
        [HttpPut] [ActionName("ActualizarJugador")]
        public Task<bool> ModifyPlayer(string email, [FromBody] Jugador jugador) {
            if(!JugadoresRepository.ExisteJugador(email)) return Task.FromResult(false);
            Jugador playerToModify = GetPlayer(email).Result;
            playerToModify.name = jugador.name;
            playerToModify.lastname = jugador.lastname;
            playerToModify.country = jugador.country;
            return JugadoresRepository.ActualizarJugador(email, playerToModify);
        }

        //DELETE: https://localhost:5001/Api/Jugadores/BorrarJugador/?email=[value]
        [HttpDelete] [ActionName("BorrarJugador")]
        public Task<bool> DeletePlayer(string email) {
            return JugadoresRepository.BorrarJugador(email);
        }

        //GET: https://localhost:5001/Api/Jugadores/GetGruposJugador/?email=[value]
        [HttpGet] [ActionName("GetGruposJugador")]
        public Task<List<GrupoFrase>> GetAllPlayerGroups(string email) {
            return JugadoresRepository.GetGruposJugador(email);
        }

        //GET: https://localhost:5001/Api/Jugadores/GetFrasesGrupoJugador/?email=[value]&nombre_grupo=[value]
        [HttpGet] [ActionName("GetFrasesGrupoJugador")]
        public Task<List<Frase>> GetAllPlayerGroupPhrases(string email, string nombre_grupo) {
            return JugadoresRepository.GetFrasesGrupoJugador(email, nombre_grupo);
        }

        //GET: https://localhost:5001/Api/Jugadores/GetFrasesGruposJugador/?email=[value]
        [HttpGet] [ActionName("GetFrasesGruposJugador")]
        public List<Frase> GetAllPlayerGroupsPhrases(string email) {
            return JugadoresRepository.GetFrasesGruposJugador(email);
        }
    }
}