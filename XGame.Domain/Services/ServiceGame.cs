using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGame.Domain.Arguments.Game;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Arguments.Base;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;

namespace XGame.Domain.Services
{
    public class ServiceGame : Notifiable, IServiceGame
    {
        private readonly IRepositoryGame _repositoryGame;

        public ServiceGame(IRepositoryGame repositoryGame)
        {
            _repositoryGame = repositoryGame;
        }

        public ServiceGame()
        {

        }

        public AddGameResponse AddGame(AddGameRequest request)
        {
            var game = new Game(request.Name, request.Description, request.Producer,
                request.Distributor, request.Gender, request.Site);

            AddNotifications(game);

            if (this.IsInvalid())
            {
                return null;
            }

            game = _repositoryGame.AddEntity(game);

            return (AddGameResponse)game;
        }

        public IEnumerable<GameResponse> ListGame()
        {
            return _repositoryGame.List()
                    .ToList()
                    .Select(game => (GameResponse)game).ToList();
        }

        public ResponseBase RemoveGame(Guid id)
        {
            var game = _repositoryGame.GetById(id);

            if (game == null)
            {
                AddNotification("Id", "Not Found");
                return null;
            }

            _repositoryGame.Remove(game);

            return new ResponseBase() { Message = "Successfull" };
        }

        public ResponseBase UpdateGame(UpdateGameRequest request)
        {
            if (request == null)
            {
                AddNotification("UpdateGameRequest", "Game value is null");
                return null;
            }

            var game = _repositoryGame.GetById(request.Id);

            if (game == null)
            {
                AddNotification("Id", "Not found");
                return null;
            }

            game.Update(request.Name, request.Description, request.Producer,
                request.Distributor, request.Gender, request.Site);

            if (IsInvalid())
            {
                return null;
            }
            _repositoryGame.Edit(game);

            return (ResponseBase)game;
        }
    }
}
