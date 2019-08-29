using Microsoft.EntityFrameworkCore;
using ProyectoSalvo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoSalvo.Models;

namespace ProyectoSalvo.Data
{
    public partial class SalvoDatabaseContext : DbContext
    {

        public SalvoDatabaseContext(DbContextOptions<SalvoDatabaseContext> options) : base(options) { }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<GamePlayer> GamePlayer { get; set; }
        public virtual DbSet<Ship> Ship { get; set; }
        public virtual DbSet<ShipLocation> ShipLocation {get; set;}
        public virtual DbSet<Models.Salvo> Salvos { get; set; }
        public virtual DbSet<Score> Score { get; set; }
        public virtual DbSet<SalvoLocation> SalvoLocation { get; set; }

    }
}
