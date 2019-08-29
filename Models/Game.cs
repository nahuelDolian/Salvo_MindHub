using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSalvo.Models
{
    public partial class Game
    {
        public long Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public ICollection<GamePlayer> GamePlayer { get; set; }
        public ICollection<Score> Scores { get; set; }
      }
}
