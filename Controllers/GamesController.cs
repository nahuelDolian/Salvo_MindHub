using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoSalvo.Data;
using ProyectoSalvo.Models;
using ProyectoSalvo.ModelViews;
using ProyectoSalvo.Repositories;

namespace ProyectoSalvo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    public class GamesController : ControllerBase
    {
        string user;
        private IGameRepository _GameRepository;
        private IPlayerRepository IPlayerRepository;
        private IGamePlayerRepository IGamePlayerRepo;
        public GamesController(IGameRepository repository, IPlayerRepository _player, IGamePlayerRepository _GamePlayer)
        {
            IGamePlayerRepo = _GamePlayer;
            _GameRepository = repository;
            IPlayerRepository = _player;
        }



        // GET : api / Game
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetGames()
        {
            var games = _GameRepository.GetAllGames();
            List<GameView> filtro = new List<GameView>();
            user = User.FindFirst("Player") != null ? User.FindFirst("Player").Value : "Guest";
            foreach (var game in games)
            {
                var g = new GameView(game);
                filtro.Add(g);
            }
            GuestPlayerDTO juegosConMails = new GuestPlayerDTO(filtro, user);
            return Ok(juegosConMails);
           
        }
        // GET : api / values/1
        [HttpGet("{id}")]
        public IActionResult GetGame(long id)
        {
            var gameDB = _GameRepository.GetThatGame(id);
            return Ok(new GameView(gameDB));
        }

        [HttpPost]
        public IActionResult CrearJuego()
        {
            if (User.FindFirst("Player") == null)
            {
                return StatusCode(403,"Debes Loguearte!");
            }
            else
            {
                string mail = User.FindFirst("Player").Value;
                Player creador = IPlayerRepository.FindByEmail(mail);
                Game juegoNuevo = new Game();
                    juegoNuevo.CreationDate = DateTime.Now;
                GamePlayer gp = new GamePlayer();
                    gp.JoinDate = DateTime.Now;
                    gp.Playerid = creador.Id;
                    gp.Game = juegoNuevo;
                IGamePlayerRepo.Save(gp);

                return StatusCode(201, gp.Id);
            
            }
        }
        [HttpPost("{id}/players")]
        [AllowAnonymous]
        public IActionResult SumarseASesion([FromRoute] long id)
        {
            if (User.FindFirst("Player") == null)
            {
                return StatusCode(403, "No iniciaste sesion");
            }
            Player player = IPlayerRepository.FindByEmail(User.FindFirst("Player").Value);
            Game juego = _GameRepository.FindById(id);
            if (juego == null)
            {
                return StatusCode(403, "Forbidden: No existe el Juego");
            }
            else
            {
                foreach (GamePlayer gamep in juego.GamePlayer)
                {
                    if (gamep.Player.Id == player.Id)
                    {
                        return StatusCode(403, "Ya estas en la sesion!");
                    }
                }
                if (juego.GamePlayer.Count > 1)
                {
                    return StatusCode(403, "la sesion esta llena :(");
                }
                GamePlayer gp = new GamePlayer();
                 gp.JoinDate = DateTime.Now;
                 gp.Playerid = player.Id;
                 //gp.Game = juego;
                 gp.Gameid = juego.Id;
                IGamePlayerRepo.Save(gp);

                return StatusCode(201, gp.Id);
            }
        }
        
    }
}