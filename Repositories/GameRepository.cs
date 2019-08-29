using Microsoft.EntityFrameworkCore;
using ProyectoSalvo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProyectoSalvo.Data;
using ProyectoSalvo.ModelViews;
using Salvo.Repositories;

namespace ProyectoSalvo.Repositories
{
    public class GameRepository : RepositoryBase<Game>, IGameRepository
    {
        private readonly SalvoDatabaseContext _context;
        public GameRepository(SalvoDatabaseContext repositoryContext)
            : base(repositoryContext)
        {
            _context = repositoryContext;
        }

        public List<Game> GetAllGames()
        {
            return FindAll(source => source.Include(g => g.GamePlayer)
                                                  .ThenInclude(gp => gp.Player)
                                            .Include(x => x.GamePlayer)
                                                  .ThenInclude(y => y.ships)
                                                      .ThenInclude(b => b.Locations)
                                             .Include(g => g.GamePlayer)
                                                  .ThenInclude(gp => gp.Player)
                                                        .ThenInclude(p => p.Scores))
                                                .ToList();
        }
        public Game GetThatGame(long id)
        {
            return FindAll(gameDB => gameDB.Include(g => g.GamePlayer).ThenInclude(gp => gp.Player)
                                    .Include(g => g.GamePlayer)
                                        .ThenInclude(gp => gp.ships).
                                            ThenInclude(ship => ship.Locations)
                                    .Include(g => g.GamePlayer)
                                        .ThenInclude(gp => gp.salvos)
                                            .ThenInclude(salvo => salvo.Locations)).
                                    Include(g => g.GamePlayer)
                                                  .ThenInclude(gp => gp.Player)
                                                        .ThenInclude(p => p.Scores)
                                    .FirstOrDefault(g => g.Id == id); 
        }
        public Game FindById(long id)
        {
            return FindAll().Include(gameDB=>gameDB.GamePlayer).ThenInclude(gp=>gp.Player)
                                                .FirstOrDefault(player => player.Id == id);
        }

    }
}
