using prmToolkit.NotificationPattern;
using System;

namespace XGame.Domain.Entities
{
    public class Game : EntityBase
    {
       
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Producer { get; private set; }
        public string Distributor { get; private set; }
        public string Gender { get; private set; }
        public string Site { get; private set; }

        public Game()
        {
        }
        public Game(string name, string description, string producer, string distributor, 
            string gender, string site)
        {
            Name = name;
            Description = description;
            Producer = producer;
            Distributor = distributor;
            Gender = gender;
            Site = site;

            new AddNotifications<Game>(this)
                .IfNullOrInvalidLength(x => x.Name, 1, 100, "Invalid input")
                .IfNullOrInvalidLength(x => x.Description, 1, 100, "Invalid input")
                .IfNullOrInvalidLength(x => x.Gender, 1, 32, "Invalid input");
        }

        public void Update(string name, string description, string producer, string distributor,
            string gender, string site)
        {
            Name = name;
            Description = description;
            Producer = producer;
            Distributor = distributor;
            Gender = gender;
            Site = site;

            new AddNotifications<Game>(this)
                .IfNullOrInvalidLength(x => x.Name, 1, 100, "Invalid input")
                .IfNullOrInvalidLength(x => x.Description, 1, 100, "Invalid input")
                .IfNullOrInvalidLength(x => x.Gender, 1, 32, "Invalid input");
        }
    }
}
