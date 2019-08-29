using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoSalvo.Models;

namespace ProyectoSalvo.ModelViews
{
    public class SalvoView
    {
        public long id { get; set; }
        public long turn { get; set; }
        public PlayerView player { get; set; }
        public ICollection<SalvoLocationView> locations { get; set; }

        public SalvoView() { }

        public SalvoView(Models.Salvo salvo)
        {
            id = salvo.Id;
            player = new PlayerView(salvo.GamePlayer.Player);
            turn = salvo.Turn;
            locations = new List<SalvoLocationView>();
            foreach(var SalvoLocation in salvo.Locations)
            {
                locations.Add(new SalvoLocationView(SalvoLocation));
            }
            
        }
    }
}
