using ProyectoSalvo.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSalvo.Models
{
    public class ShipLocation
    {
       public long Id { get; set; }
       public long ShipId { get; set; }
       public string Location { get; set; }
       public string Ship { get; set; }

    }
}
