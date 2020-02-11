using System;

namespace XGame.Domain.Entities
{
    public class GamePlatform
    {
        public Guid Id { get; set; }
        public Game Game { get; set; }
        public Platform Platform { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
