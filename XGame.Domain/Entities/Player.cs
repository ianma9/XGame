using prmToolkit.NotificationPattern;
using System;
using XGame.Domain.Enums;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Entities
{
    public class Player : Notifiable
    {
        public Player()
        {

        }
        public Player(Name name, Email email)
        {
            Name = name;
            Email = email;

            new AddNotifications<Player>(this)
                .IfNotEmail(x => x.Email.Address, "A Valid Email is required!")
                .IfNullOrInvalidLength(x => x.Password, 6, 32, "Minnimun is 6 characters!");
        }

        public Guid Id { get; set; }
        public Name Name { get; set; }
        public Email Email { get; set; }
        public string Password { get; set; }
        public EnumStatusPlayer Status { get; set; }

    }
}
