using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using XGame.Domain.Arguments.Player;
using XGame.Domain.Entities;
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

            if (this.IsInvalid())
            {
                return null;
            }

            player = _repositoryPlayer.AddPlayer(player);

            return (AddPlayerResponse) player;
        }

        public UpdatePlayerResponse UpdatePlayer(UpdatePlayerRequest request)
        {
            if (request == null)
            {
                AddNotification("PlayerAuthenticationRequest", string.Format(Message.X0_IS_REQUIRED, "PlayerAuthenticationRequest"));
            }

            Player player = _repositoryPlayer.GetPlayerById(request.Id);

            if (player == null)
            {
                AddNotification("Id", "Dados não encontrados!");
                return null;
            }
            var name = new Name(request.FirstName, request.LastName);
            var email = new Email(request.Email);

            player.ChangePlayer(name, email, player.Status);

            AddNotifications(player);

            if (IsInvalid())
            {
                return null;
            }

            _repositoryPlayer.UpdatePlayer(player);
            return (UpdatePlayerResponse) player;
        }

        public PlayerAuthenticationResponse PlayerAuthentication(PlayerAuthenticationRequest request)
        {
            if(request == null)
            {
                AddNotification("PlayerAuthenticationRequest", string.Format(Message.X0_IS_REQUIRED, "PlayerAuthenticationRequest"));
            }
            
            var email = new Email("ian@gmail.com");
            var player = new Player(email, "222554454");

            AddNotifications(player);

            if (player.IsInvalid())
            {
                return null;
            }

           // player = _repositoryPlayer.PlayerAuthentication(player.Email.Address, player.Password);
            

            return (PlayerAuthenticationResponse) player;
        }
   
        public IEnumerable<PlayerResponse> ListPlayer()
        {
            return _repositoryPlayer.ListPlayer()
                .ToList()
                .Select(player => (PlayerResponse )player).ToList();
        }
    }
}
