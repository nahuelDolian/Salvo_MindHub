using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSalvo.Models
{
    public class Ship
    {
        public string Type { get; set; }
        public long Id { get; set; }
        public long GamePlayerID { get; set; }
        public GamePlayer GamePlayer { get; set; }
        public ICollection<ShipLocation> Locations { get; set; }
        public long Lenght { get; set; }
    }
}
