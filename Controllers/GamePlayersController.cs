using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoSalvo.Models;
using ProyectoSalvo.ModelViews;
using ProyectoSalvo.Repositories;
using System.Collections.Generic;

namespace ProyectoSalvo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("PlayerOnly")]

    public class GamePlayersController : ControllerBase
    {
        private IGamePlayerRepository _repository;
        private IPlayerRepository playerRepo;
        public GamePlayersController(IGamePlayerRepository gameplayerrepository, IPlayerRepository playerRepository)
        {
            playerRepo = playerRepository;
            _repository = gameplayerrepository;
        }
        // GET : api / GamePlayers
        [HttpGet]
        public IActionResult GetGamePlayers(long id)
        {
            return Ok(_repository.GetGamePlayerView(id));
        }
        // GET : api / gameplayer/1
        [HttpGet("{id}")]  // "atributos" de ASP.NET
        public IActionResult Get(long id)
        {
            var gameplayer = _repository.GetGamePlayerView(id);
            var mail = User.FindFirst("Player") != null ? User.FindFirst("Player").Value : "Guest";
            if (gameplayer.Player.Email == mail)
            {
                return Ok(new GameViewDTO(gameplayer));
            }
            else
            {
                return Forbid();
            }

        }
        public double GetScore()
        {
            return 1;
        }


        public Ship shippiar(ShipView shipView)
        {
            var ship = new Ship();
            ship.Id = shipView.Id;
            ship.Type = shipView.Type;
            ship.Locations = new List<ShipLocation>();
            foreach (ShipLocationView shipVLoc in shipView.Locations)
            {
                ShipLocation shipLoca = new ShipLocation();
                shipLoca.Location = shipVLoc.Location;
                shipLoca.Id = shipVLoc.Id;
                ship.Locations.Add(shipLoca);
            }
            return ship;
        }
      
 
        public Models.Salvo salvear(SalvoView salvoView, long gamePlayerId)
        {
            GamePlayer gameplayer = _repository.FindById(gamePlayerId);
            int ultimoTurno;
            if (gameplayer.salvos == null)
            {
                ultimoTurno = 0;
            } else
            {
                ultimoTurno = gameplayer.salvos.Count;
            }
           

            var salvo = new Models.Salvo();
            salvo.Locations = new List<SalvoLocation>();
            salvo.Turn = ultimoTurno + 1;
            foreach (SalvoLocationView salvoVloc in salvoView.locations)
            {
                SalvoLocation SalvoLoco = new SalvoLocation();
                SalvoLoco.Location = salvoVloc.location;
                salvo.Locations.Add(SalvoLoco);
                
            }
            return salvo;
        }


        [HttpPost("/api/gamePlayers/{gamePlayerId}/ships")]
        public IActionResult PosicionarBarcos([FromBody] ICollection<ShipView> ships, long gamePlayerId)
        {
            GamePlayer gameplayer = _repository.FindById(gamePlayerId);
            if (gameplayer == null)
            {
                return StatusCode(403, "no existe el plasher");
            }
            Player playerSession = playerRepo.FindByEmail(User.FindFirst("Player").Value);

            if (gameplayer.Playerid != playerSession.Id)
            {
                return StatusCode(403, "El usuario no se encuentra en el juego!");
            }
            if (gameplayer.ships.Count == 5)
            {
                return StatusCode(403, "Ya se posicionaron sus barcos!");
            }
            List<Ship> naves = new List<Ship>();
            foreach (var ship in ships)
            {
                naves.Add(shippiar(ship));
            }
            gameplayer.ships = naves;
            _repository.Save(gameplayer);
            return StatusCode(201, gameplayer.Id);
        }



        [HttpPost("{gamePlayerId}/salvos")]
        public IActionResult DispararSalvos(long gamePlayerId, [FromBody] SalvoView salvo)
        {

            GamePlayer gameplayer = _repository.FindById(gamePlayerId);    // repito logica con todas las validaciones
            if (gameplayer == null)
            {
                return StatusCode(403, "no existe el plasher");
            }
            Player playerSession = playerRepo.FindByEmail(User.FindFirst("Player").Value);

            if (gameplayer.Playerid != playerSession.Id)
            {
                return StatusCode(403, "El usuario no se encuentra en el juego!");
            }
            if (gameplayer.Game.GamePlayer.Count == 2)
            {
                GamePlayer contrincante = gameplayer.Rival();
                if (gameplayer.salvos == null)
                {
                    gameplayer.salvos = new List<Models.Salvo>();
                }
                if (contrincante.salvos == null)
                {
                    contrincante.salvos = new List<Models.Salvo>();
                }
                if (gameplayer.JoinDate < contrincante.JoinDate && gameplayer.salvos.Count == contrincante.salvos.Count)   //aca tomo al que es mano, desp debo comparar los turnos y bla
                {   //si el mano tiene los mismos turnos, juega él
                    gameplayer.salvos.Add(salvear(salvo, gamePlayerId));
                    _repository.Save(gameplayer);
                    return StatusCode(201, gameplayer.Id);
                }
                else if (gameplayer.JoinDate > contrincante.JoinDate && gameplayer.salvos.Count < contrincante.salvos.Count)
                {  //si el pie tiene la misma cantidad de turnos, debe permitir a él jugar
                    gameplayer.salvos.Add(salvear(salvo, gamePlayerId));
                    _repository.Save(gameplayer);
                    return StatusCode(201, gameplayer.Id);
                }
                return StatusCode(401, "espera tu turno");
            } else
            {
                return StatusCode(403, "Debes esperar al contrincante pa jugar ñery");
            }
        }
    }
}