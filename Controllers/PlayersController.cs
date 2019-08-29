using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class PlayersController : ControllerBase
    {
        private IPlayerRepository IPlayerRepository;
        public PlayersController(IPlayerRepository _player)
        {
            IPlayerRepository = _player;
        }

        PlayerRepository _repository;
        // GET : api / Players
        [HttpGet]
        public IActionResult GetPlayers()
        {
            return Ok(IPlayerRepository.GetPlayers());
        }
        public IActionResult CrearJugador(PlayerView player)
        {
            try
            {
                var playerLogued = IPlayerRepository.FindByEmail(player.Email);

                // response.data -> te da el String del error / sino, response solo tira todo el Error
                if (playerLogued == null)
                {
                    if (String.IsNullOrWhiteSpace(player.Email)|| String.IsNullOrWhiteSpace(player.Password))
                    {
                        return StatusCode(403, "Datos Invalidos");
                    }
                    else
                    {
                       
                        Player p = new Player {
                            Email = player.Email,
                            Password = player.Password };
                        IPlayerRepository.Save(p);
                        return StatusCode(201, "Guardado con exito");
                    }
                }
                else
                {
                    return StatusCode(403, "El Usuario Existe ñery");
                }

            }
            catch (Exception ex)
            {

                return StatusCode(500,"Falla maestra :]");
            }
          
        }
    }

}