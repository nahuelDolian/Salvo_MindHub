using ProyectoSalvo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSalvo.ModelViews
{
    public class GamePlayerDTO
    {

        public long Id { get; set; }
        public DateTime? JoinDate { get; set; }
        public PlayerView Player { get; set; }
      

        public GamePlayerDTO(GamePlayer gameplayer)
        {
            Id = gameplayer.Playerid;
            Player = new PlayerView(gameplayer.Player);
            JoinDate = gameplayer.JoinDate;
          

        }
        public GamePlayerDTO() { }

        public ICollection<string> PosicionesDeMisSalvos(GamePlayer gamePlayer)
        {
            List<string> tirados = new List<string>();
            foreach (var salvos in gamePlayer.salvos)
            {
                foreach (var ubicaciones in salvos.Locations)
                {
                    var tiroPuntual = ubicaciones.Location;
                    tirados.Add(tiroPuntual);
                }
            }
            return tirados;
        }

        public ICollection<string> PosicionesDeShipsDelRival(GamePlayer gamePlayer)
        {
            List<string> shipsLocations = new List<string>();
            foreach (var salvos in gamePlayer.Rival().ships)
            {
                foreach (var ubicaciones in salvos.Locations)
                {
                    var tiroPuntual = ubicaciones.Location;
                    shipsLocations.Add(tiroPuntual);
                }
            }
            return shipsLocations;
        }
        public ICollection<string> PosicionesDeMisSalvosXTurno(GamePlayer gamePlayer)
        {
            return null;
        }

        public IEnumerable<string> getHits(GamePlayer gamePlayer)
        {
            ICollection<string> misTiros = PosicionesDeMisSalvos(gamePlayer);
            ICollection<string> misObjetivos = PosicionesDeShipsDelRival(gamePlayer.Rival());

            IEnumerable<string> myHits = misTiros.Intersect(misObjetivos);
            return myHits;
        }
    }
}
