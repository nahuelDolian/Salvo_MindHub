using ProyectoSalvo.Models;
using ProyectoSalvo.ModelViews;
using Salvo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSalvo.Repositories
{
    public interface IGameRepository
    {
        List<Game> GetAllGames();
        Game FindById(long id);
        Game GetThatGame(long id);
    }
}
