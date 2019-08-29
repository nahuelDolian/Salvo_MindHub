using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoSalvo.Models;

namespace ProyectoSalvo.ModelViews
{
    public class SalvoLocationView
    {
        public long  Id{ get; set; }
        public string location { get; set; }

        public SalvoLocationView(SalvoLocation salvolocation)
        {
            Id = salvolocation.Id;
            location = salvolocation.Location;
        }
        public SalvoLocationView() { }

    }
}
