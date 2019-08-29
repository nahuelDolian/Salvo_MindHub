using ProyectoSalvo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSalvo.ModelViews
{
    public class PlayerView
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public PlayerView(Player player)
        {
            Id = player.Id;
            Email = player.Email;
            Password = player.Password;
        }

        // Se necesita para darle forma de objeto al "JSON" de index.html
        public PlayerView() { }
    }
}
