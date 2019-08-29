using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoSalvo.Models;

namespace ProyectoSalvo.ModelViews
{
    public class ShipView
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public ICollection<ShipLocationView> Locations { get; set; }

        public ShipView(Ship ship)
        {
            Id = ship.Id;
            Type = ship.Type;
            Locations = new List<ShipLocationView>();
            foreach (var shipLocation in ship.Locations)
            {
                Locations.Add(new ShipLocationView(shipLocation));
            }
        }
        public ShipView() { }
    }
}
