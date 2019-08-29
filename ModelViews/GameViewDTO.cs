using ProyectoSalvo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProyectoSalvo.ModelViews
{
    public class GameViewDTO
    {
        public long Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public List<GamePlayerDTO> GamePlayers { get; set; }
        public ICollection<ShipView> Ships { get; set; }
        public ICollection<SalvoView> Salvos { get; set; }
        public ICollection<HitDTO> hits { get; set; }
        public ICollection<HitDTO> hitsOpponent { get; set; }
        public ICollection<string> sunks { get; set; }
        public ICollection<string> sunksOpponent { get; set; }

        public GameViewDTO(GamePlayer gameplayer)
        {
            CreationDate = gameplayer.Game.CreationDate;
            Id = gameplayer.Id;
            GamePlayers = new List<GamePlayerDTO>();
            Ships = new List<ShipView>();
            Salvos = new List<SalvoView>();
            foreach (var gP in gameplayer.Game.GamePlayer)
            {
                GamePlayers.Add(new GamePlayerDTO(gP));

               foreach (var salvos in gP.salvos)
                {
                    Salvos.Add(new SalvoView(salvos));
                
                }
            }
            foreach (var ship in gameplayer.ships)
            {
                Ships.Add(new ShipView(ship));
            }


            hits = new List<HitDTO>();
            foreach(var salvo in gameplayer.salvos)
            {
                hits.Add(new HitDTO(salvo));
            }
            hitsOpponent = new List<HitDTO>();
            if(gameplayer.Game.GamePlayer.Count == 2)
            {


                foreach (var salvo in gameplayer.Rival().salvos)
                {
                    hitsOpponent.Add(new HitDTO(salvo));
                }
                sunks = new List<string>();
                foreach (var barcoRival in gameplayer.Rival().ships)
                {
                    if (sunkearBarco(barcoRival) != null)
                    {
                        sunks.Add(barcoRival.Type);
                    }
                }
                sunksOpponent = new List<string>();
                foreach (var miBarco in gameplayer.ships)
                {
                    if (sunkearBarco(miBarco) != null) // falla porque estoy pasandoles mis salvos en la comparación.-
                    {
                        sunksOpponent.Add(miBarco.Type);
                    }
                }
            }
        }

        //public string elBarcoEstaSunkeadoPor(Ship ship, GamePlayer gamePlayer)
        //{
        //    List<string> tirados = new List<string>();
        //    tirados = PosicionesDeMisSalvos(gamePlayer); // $ ship.gameplayer.rival()
        //    List<string> shipLocations = new List<string>();
        //    foreach (var ubicaciones in ship.Locations)
        //    {
        //        var esaUbicacion = ubicaciones.Location;
        //        shipLocations.Add(esaUbicacion);
        //    }
        //    if (ContainsAllItems(tirados, shipLocations))
        //    { return ship.Type; }
        //    else { return null; }
        //}

        public string sunkearBarco(Ship ship)  //para el suncksOpponent tengo que pasarle la lista de los tiros del contrincante
        {                                       // las naves, las paso por parametro en su implementacion
            List<string> tirados = new List<string>();
            tirados = PosicionesDeMisSalvos(ship.GamePlayer); // $ ship.gameplayer.rival()
            List<string> shipLocations = new List<string>();
            foreach (var ubicaciones in ship.Locations)
            {
                var esaUbicacion = ubicaciones.Location;
                shipLocations.Add(esaUbicacion);
            }
            if (ContainsAllItems(tirados, shipLocations))
            { return ship.Type; }
            else { return null; }
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
        public static bool ContainsAllItems(List<string> a, List<string> b)
        {
            return !b.Except(a).Any();
        }

        public GameViewDTO()
        {
        }
    }

}