using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoSalvo.Models;
using ProyectoSalvo.Data;
using Salvo.Repositories;
using ProyectoSalvo.ModelViews;

namespace ProyectoSalvo.Repositories
{
    public class GamePlayerRepository : RepositoryBase <GamePlayer>, IGamePlayerRepository
    {
        private readonly SalvoDatabaseContext _context;

        public GamePlayerRepository (SalvoDatabaseContext repositoryContext)
            : base(repositoryContext)
    {
            _context = repositoryContext;
        }

        public List<GamePlayer> GetGamePlayerList()
        {
                return _context.GamePlayer.Include(x => x.Game).Include(x => x.Player).ToList();
        }
        public List<GamePlayer> GetGamePlayerList(long idGame)
        {
                return _context.GamePlayer.Where(r => r.Gameid == idGame).ToList();
        }
        
        public GamePlayer GetGamePlayer(long idGamePlayer)
        {
            return FindAll(source => source.Include(gamePlayer => gamePlayer.ships)
                                                 .ThenInclude(ship => ship.Locations)
                                             .Include(gamePlayer => gamePlayer.Game)
                                                 .ThenInclude(game => game.GamePlayer)
                                                     .ThenInclude(gp => gp.Player)
                                             .Include(gameplayer => gameplayer.salvos)
                                                .ThenInclude(salvos => salvos.Locations)
                                             )
                 .Where(gamePlayer => gamePlayer.Id == idGamePlayer)
                 .OrderBy(game => game.JoinDate)
                 .FirstOrDefault();
        }
        public GamePlayer CreateGamePlayer(long gameId, long playerId)
        {
            {
                GamePlayer nuevoGamePlayer = new GamePlayer();
                nuevoGamePlayer.JoinDate = DateTime.Now;
                nuevoGamePlayer.Gameid = gameId;
                nuevoGamePlayer.Playerid = playerId;
                _context.GamePlayer.Add(nuevoGamePlayer);
                _context.SaveChanges();
                return nuevoGamePlayer;
            }
            
        }
        public GamePlayer GetGamePlayerView(long idGamePlayer)
        {
            return FindAll(source => source
                                            //.Include(gamePlayer => gamePlayer.ships)
                                            //    .ThenInclude(ship => ship.Locations)
                                            .Include(gamePlayer => gamePlayer.Game)
                                                .ThenInclude(game => game.GamePlayer)
                                                    .ThenInclude(gp => gp.Player)
                                            .Include(gamePlayer => gamePlayer.Game)
                                                .ThenInclude(game => game.GamePlayer)
                                                    .ThenInclude(gp => gp.salvos)
                                                        .ThenInclude(salvo => salvo.Locations)
                                            .Include(gamePlayer => gamePlayer.Game)
                                                .ThenInclude(game => game.GamePlayer)
                                                    .ThenInclude(gp => gp.ships)
                                                     .ThenInclude(ship => ship.Locations)
                                            )
                .Where(gamePlayer => gamePlayer.Id == idGamePlayer)
                .OrderBy(game => game.JoinDate)
                .FirstOrDefault();
        }
        public void Save(GamePlayer gameplayer)
        {
            if (gameplayer.Id == 0)
                Create(gameplayer);
            else
                Update(gameplayer);
            SaveChanges();
        }
        public GamePlayer FindById(long id)
        {
            return FindAll(source => source
                        .Include(gp => gp.Game).ThenInclude(game => game.GamePlayer)
                            .ThenInclude(gameplayer => gameplayer.Player)
                        .Include(gp => gp.Game).ThenInclude(game => game.GamePlayer)
                            .ThenInclude(gameplayer => gameplayer.ships)
                            .ThenInclude(Ships=>Ships.Locations)
                        //.Include(gameplayer => gameplayer.salvos)
                        //    .ThenInclude(sa=>sa.Locations)
                        .Include(gp=>gp.Game).ThenInclude(game=>game.GamePlayer)
                            .ThenInclude(gameplayer => gameplayer.salvos)
                                .ThenInclude(sa => sa.Locations))
                        .FirstOrDefault(gameplayer => gameplayer.Id == id);
        }
    }
}

