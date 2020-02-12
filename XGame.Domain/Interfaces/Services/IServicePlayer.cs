using System;
using System.Collections.Generic;
using XGame.Domain.Arguments.Player;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Interfaces.Services
{
    public interface IServicePlayer
    {
        PlayerAuthenticationResponse PlayerAuthentication(PlayerAuthenticationRequest request);
        AddPlayerResponse AddPlayer(AddPlayerRequest request);
        UpdatePlayerResponse UpdatePlayer(UpdatePlayerRequest request);

        IEnumerable<PlayerResponse> ListPlayer();
    }
}
