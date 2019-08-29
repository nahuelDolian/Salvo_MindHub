using Microsoft.AspNetCore.Http;
using ProyectoSalvo.Controllers;
using ProyectoSalvo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSalvo.ModelViews
{
    public class GuestPlayerDTO
    {
        public string Email { get; set; }
        public ICollection<GameView> Games { get; set; }

        public GuestPlayerDTO(List<GameView> games, string email)
        {
            Email = email;
            Games = games;
        }
        public GuestPlayerDTO() { }
        
    }
}
