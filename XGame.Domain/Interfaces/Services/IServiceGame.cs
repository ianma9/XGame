using System;
using System.Collections.Generic;
using XGame.Domain.Arguments.Game;
using XGame.Domain.Interfaces.Arguments.Base;
using XGame.Domain.Interfaces.Services.Base;

namespace XGame.Domain.Interfaces.Services
{
    public interface IServiceGame : IServiceBase
    {
        IEnumerable<GameResponse> ListGame();
        AddGameResponse AddGame(AddGameRequest request);
        ResponseBase RemoveGame(Guid id);
        ResponseBase UpdateGame(UpdateGameRequest request);
    }
}
