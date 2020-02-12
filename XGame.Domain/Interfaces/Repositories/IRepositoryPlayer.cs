using System;
using System.Collections;
using System.Collections.Generic;
using XGame.Domain.Arguments.Player;
using XGame.Domain.Entities;

namespace XGame.Domain.Interfaces.Repositories
{
    public interface IRepositoryPlayer
    {
        Player PlayerAuthentication(string email, string password);
        Player AddPlayer(Player player);
        IEnumerable<Player> ListPlayer();
        Player GetPlayerById(Guid id);
        void UpdatePlayer(Player player);
    }
}
