using System;

namespace XGame.Domain.Entities
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Producer { get; set; }
        public string Distributor { get; set; }
        public string Gender { get; set; }
        public string Site { get; set; }
    }
}
