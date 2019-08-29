using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoSalvo.Models;
using ProyectoSalvo.Repositories;
using Salvo.Repositories;

namespace ProyectoSalvo.Repositories
{
    public interface IPlayerRepository
    {
        List<Player> GetPlayers();
        Player GetPlayerById(long id);
        Player FindByEmail(string email);
        void Save(Player player);
    }
}
