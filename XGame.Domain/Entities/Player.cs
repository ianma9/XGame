using System;
using XGame.Domain.Enums;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Entities
{
    public class Player
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }
        public Email Email { get; set; }
        public string Password { get; set; }
        public EnumStatusPlayer Status { get; set; }

    }
}
