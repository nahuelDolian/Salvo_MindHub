using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSalvo.Models
{
    public class GamePlayer 
    {
        public long Id { get; set; }
        public DateTime JoinDate { get; set; }
        public long Playerid { get; set; }
        public long Gameid { get; set; }
        public Game Game { get; set; }
        public Player Player { get; set; }
        public ICollection<Ship> ships { get; set; } //pasar a mayus
        public ICollection<Salvo> salvos
        { get; set; } // pasar a mayus


        public GamePlayer() { }
        public Score GetScore()
        {
            return Player.GetScore(Game);
        }
        public GamePlayer Rival()
        {
            return Game.GamePlayer.FirstOrDefault(plasher => plasher.Id != Id);
        }
    }
}
