using prmToolkit.NotificationPattern;
using System;
using XGame.Domain.Enums;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Entities
{
    public class Player : Notifiable
    {
        public Player(Email email, string password)
        {
            Email = email;
            Password = password;

            new AddNotifications<Player>(this)
                .IfNotEmail(x => x.Email.Address, "A Valid Email is required!")
                .IfNullOrInvalidLength(x => x.Password, 6, 32, "Minnimun is 6 characters!");
        }

        public Player(Name name, Email email, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
            Status = EnumStatusPlayer.InProgress;


            new AddNotifications<Player>(this)
                .IfNullOrInvalidLength(x => x.Password, 6, 32,
                "Between 6 and 32 characters!");

            AddNotifications(name, email);
        }

        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public string Password { get; private set; }
        public EnumStatusPlayer Status { get; private set; }

        public void ChangePlayer(Name name, Email email, EnumStatusPlayer status)
        {
            Name = name;
            Email = email;

            new AddNotifications<Player>(this).IfFalse(Status == EnumStatusPlayer.Active, "Inative Player!");
            AddNotifications(name, email);
        }

    }
}
