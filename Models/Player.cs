using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProyectoSalvo.Models
{
    public partial class Player
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<GamePlayer> GamePlayer { get; set; }
     
        public ICollection<Score> Scores { get; set; }
        public Score GetScore(Game game)
        {
            return Scores.FirstOrDefault(score => score.GameId == game.Id);
            
        }
    }
}
