using ProyectoSalvo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSalvo.ModelViews
{
    public class HitDTO
    {
        public long turn { get; set; }
        public ICollection<HitLocationView> hits{ get; set; }

        public HitDTO(Models.Salvo salvo)
        {
            turn = salvo.Turn;
            hits = new List<HitLocationView>();
            foreach (var barquito in salvo.GamePlayer.Rival().ships)
            {
                HitLocationView hitLocationView = new HitLocationView(salvo, barquito);
                hits.Add(hitLocationView);
            }
        }
    }
}
