using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ProyectoSalvo.Models;
using ProyectoSalvo.ModelViews;

namespace ProyectoSalvo.ModelViews
{
    public class GameView
    {
        public long id { get; set; }
        public DateTime? creationDate { get; set; }
        public List<GamePlayerView> gamePlayers { get; set; }

        public GameView(Game game)
        {
            id = game.Id;
            creationDate = game.CreationDate;
          
            gamePlayers = new List<GamePlayerView>();
            
            foreach (var gP in game.GamePlayer)
            {
                gamePlayers.Add(new GamePlayerView(gP));
            }
        }
        public GameView() { }
    }
}
