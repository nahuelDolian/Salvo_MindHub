using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoSalvo.Models;

namespace ProyectoSalvo.ModelViews
{
    public class ShipLocationView
    {
        public long Id { get; set; }
        public string  Location { get; set; }

    public ShipLocationView(ShipLocation locations)
        {
            Id = locations.Id;
            Location = locations.Location;
        }
    public ShipLocationView() { }
    }
}
