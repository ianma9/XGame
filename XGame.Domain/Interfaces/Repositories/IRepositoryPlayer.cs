using System;
using XGame.Domain.Arguments.Player;
using XGame.Domain.Entities;

namespace XGame.Domain.Interfaces.Repositories
{
    public interface IRepositoryPlayer
    {
        PlayerAuthenticationResponse PlayerAuthentication(PlayerAuthenticationRequest request);
        Guid AddPlayer(Player player);
    }
}
