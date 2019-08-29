using Microsoft.AspNetCore.Http;
using ProyectoSalvo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSalvo.ModelViews
{
    public class GamePlayerView
    {
        public long Id { get; set; }
        public DateTime ? JoinDate { get; set; }
        public PlayerView Player {  get; set; }
        public double? Point { get; set; }

        public GamePlayerView(GamePlayer gameplayer)
        {
            Id = gameplayer.Id;
            Player = new PlayerView(gameplayer.Player);
            JoinDate = gameplayer.JoinDate;
            Point = gameplayer.GetScore() != null ? gameplayer.GetScore().Point : 0;
            
        }
        public GamePlayerView() { }
    }
}
