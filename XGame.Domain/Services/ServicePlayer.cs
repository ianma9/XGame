using System;
using XGame.Domain.Arguments.Player;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;

namespace XGame.Domain.Services
{
    public class ServicePlayer : IServicePlayer
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
            Player player = new Player();

            player.Email = request.Email;
            player.Name = request.Name;
            player.Password = request.Password;
            player.Status = Enums.EnumStatusPlayer.InProgress;

            Guid id = _repositoryPlayer.AddPlayer(player);

            player.Status = Enums.EnumStatusPlayer.Active;

            return new AddPlayerResponse() { Id = id, Message = "Successful" };
        }

        public PlayerAuthenticationResponse PlayerAuthentication(PlayerAuthenticationRequest request)
        {
            if(request == null)
            {
                throw new Exception("Required");
            }
            if (string.IsNullOrEmpty(request.Email))
            {
                throw new Exception("Required");
            }
            if (IsEmail(request.Email))
            {
                throw new Exception("Required");
            }
            if (string.IsNullOrEmpty(request.Password))
            {
                throw new Exception("Required");
            }
            if (request.Password.Length < 6)
            {
                throw new Exception("Minnimun 6 characters");
            }

            var response = _repositoryPlayer.PlayerAuthentication(request);

            return response;
        }

        private bool IsEmail(string email)
        {
            return false;
        }
    }
}
