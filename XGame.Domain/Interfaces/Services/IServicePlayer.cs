using System;
using System.Collections.Generic;
using XGame.Domain.Arguments.Player;
using XGame.Domain.Interfaces.Arguments.Base;
using XGame.Domain.Interfaces.Services.Base;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Interfaces.Services
{
    public interface IServicePlayer : IServiceBase
    {
        PlayerAuthenticationResponse PlayerAuthentication(PlayerAuthenticationRequest request);
        AddPlayerResponse AddPlayer(AddPlayerRequest request);
        UpdatePlayerResponse UpdatePlayer(UpdatePlayerRequest request);
        IEnumerable<PlayerResponse> ListPlayer();
        ResponseBase RemovePlayer(Guid id);
    }
}
