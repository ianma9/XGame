using System;
using XGame.Domain.Entities;

namespace XGame.Domain.Arguments.Game
{
    public class GameResponse
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Producer { get; private set; }
        public string Distributor { get; private set; }
        public string Gender { get; private set; }
        public string Site { get; private set; }

        public static explicit operator GameResponse(Entities.Game entity)
        {
            return new GameResponse()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Producer = entity.Producer,
                Distributor = entity.Distributor,
                Gender = entity.Gender,
                Site = entity.Site
            };
            
        }
    }
}
