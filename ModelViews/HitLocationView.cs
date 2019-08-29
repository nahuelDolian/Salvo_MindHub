using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoSalvo.Models;

namespace ProyectoSalvo.ModelViews
{
    public class HitLocationView
    {
        public string type{ get; set; }
        public List<string> hits { get; set; }

        public HitLocationView(Models.Salvo salvo, Ship suBarco)
        {
            type = suBarco.Type;
            hits = getHits(salvo, suBarco);
        }

        public List<string> getHits(Models.Salvo salvo, Ship suBarco)
        {
            List<string> efectivos = new List<string>();
            foreach (var ubicaciones in salvo.Locations)
            {
                ICollection<string> hits = PosicionesDeShipsDelRival(salvo.GamePlayer.Rival())
                    .Where(a => a.Equals(ubicaciones.Location)).ToList();
                efectivos.AddRange(hits);
            }
            return efectivos;
            //List<string> misTiros = PosicionesDeMisSalvos(gamePlayer);
            //List<string> misObjetivos = PosicionesDeShipsDelRival(gamePlayer.Rival());

            //List<string> myHits = misTiros.Intersect(misObjetivos).ToList();
            //return myHits;
        }

        public List<string> PosicionesDeMisSalvos(GamePlayer gamePlayer)
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

        public List<string> PosicionesDeShipsDelRival(GamePlayer gameplayerRival)
        {
            List<string> shipsLocations = new List<string>();
            foreach (var shipRival in gameplayerRival.ships)
            {
                foreach (var ubicacionesShipRival in shipRival.Locations)
                {
                    var tiroPuntual = ubicacionesShipRival.Location;
                    shipsLocations.Add(tiroPuntual);
                }
            }
            return shipsLocations;
        }
       
    }
}
