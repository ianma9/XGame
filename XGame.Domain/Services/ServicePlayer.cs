using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using XGame.Domain.Arguments.Player;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Arguments.Base;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;
using XGame.Domain.Resources;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Services
{
    public class ServicePlayer : Notifiable, IServicePlayer
    {
        private readonly IRepositoryPlayer _repositoryPlayer;

        public ServicePlayer(IRepositoryPlayer repositoryPlayer)
        {
            _repositoryPlayer = repositoryPlayer;
        }
        public ServicePlayer()
        {
                
        }

        public AddPlayerResponse AddPlayer(AddPlayerRequest request)
        {
            var name = new Name(request.FirstName, request.LastName);
            var email = new Email(request.Email);

            Player player = new Player(name, email, request.Password);

            AddNotifications(name, email);

            if (_repositoryPlayer.Exist(x => x.Email.Address == request.Email))
            {
                AddNotification("Email", "This email already exist!");
            }

            if (this.IsInvalid())
            {
                return null;
            }

            player = _repositoryPlayer.AddEntity(player);

            return (AddPlayerResponse) player;
        }

        public UpdatePlayerResponse UpdatePlayer(UpdatePlayerRequest request)
        {
            if (request == null)
            {
                AddNotification("PlayerAuthenticationRequest", string.Format(Message.X0_IS_REQUIRED, "PlayerAuthenticationRequest"));
            }

            Player player = _repositoryPlayer.GetById(request.Id);

            if (player == null)
            {
                AddNotification("Id", "Dados não encontrados!");
                return null;
            }
            var name = new Name(request.FirstName, request.LastName);
            var email = new Email(request.Email);

            player.UpdatePlayer(name, email, player.Status);

            AddNotifications(player);

            if (IsInvalid())
            {
                return null;
            }

            return (UpdatePlayerResponse) player;
        }

        public PlayerAuthenticationResponse PlayerAuthentication(PlayerAuthenticationRequest request)
        {
            if(request == null)
            {
                AddNotification("PlayerAuthenticationRequest", string.Format(Message.X0_IS_REQUIRED, "PlayerAuthenticationRequest"));
            }
            
            var email = new Email(request.Email);
            Player player = new Player(email, request.Password);

            AddNotifications(player, email);

            if (player.IsInvalid())
            {
                return null;
            }

            player = _repositoryPlayer.GetBy(x => x.Email.Address == player.Email.Address &&
               x.Password == player.Password);
            

            return (PlayerAuthenticationResponse) player;
        }
   
        public IEnumerable<PlayerResponse> ListPlayer()
        {
            return _repositoryPlayer.List()
                .ToList()
                .Select(player => (PlayerResponse )player).ToList();
        }

        public ResponseBase RemovePlayer(Guid id)
        {
            Player player = _repositoryPlayer.GetById(id);

            if (player == null)
            {
                AddNotification("Id", "Não encontrado!");
                return null;
            }

            _repositoryPlayer.Remove(player);

            return new ResponseBase();
        }
    }
}
