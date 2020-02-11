using System;
using XGame.Domain.Interfaces.Arguments;

namespace XGame.Domain.Arguments.Player
{
    public class AddPlayerResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}
