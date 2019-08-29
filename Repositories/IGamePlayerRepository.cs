using ProyectoSalvo.Models;
using ProyectoSalvo.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSalvo.Repositories
{
    public interface IGamePlayerRepository
    {
        List<GamePlayer> GetGamePlayerList();
        GamePlayer GetGamePlayerView(long id);
        GamePlayer CreateGamePlayer(long gameId, long playerId);
        void Save(GamePlayer gameplayer);
        GamePlayer FindById(long id);



    }
}
