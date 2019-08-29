using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoSalvo.ModelViews;

namespace ProyectoSalvo.Models
{
    public class Salvo
    {
        public long Id { get; set; }
        public long GamePlayerId { get; set; }
        public GamePlayer  GamePlayer{ get; set; }
        public long Turn { get; set; }
        public ICollection<SalvoLocation> Locations { get; set; }
        
        public  Salvo (){}
    }
}
