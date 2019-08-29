using ProyectoSalvo.Models;
using ProyectoSalvo.Repositories;
using System.Collections.Generic;
using System.Linq;
using ProyectoSalvo.Data;
using Salvo.Repositories;
using System;

namespace ProyectoSalvo.Repositories
{
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
        private readonly SalvoDatabaseContext _context;

        public PlayerRepository(SalvoDatabaseContext repositoryContext)
            : base(repositoryContext)
        {
            _context = repositoryContext;
        }
        public List<Player> GetPlayers()
        {
                var todos = _context.Player.ToList();
                return todos;

        }
        public Player GetPlayerById(long playerid)
        {
            List<Player> players = GetPlayers();
            foreach (Player player in players)
            {
                if (player.Id == playerid)
                {
                    return player;
                }
            }
            return null;
        }
        public Player FindByEmail(string mail)
        {
            return FindAll().FirstOrDefault(player => player.Email == mail);
        }
        public void Save(Player player)
        {
            Create(player);
            SaveChanges();
        }
    }
}
