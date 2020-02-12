using System;
using XGame.Domain.Entities;

namespace XGame.Domain.Arguments.Player
{
    public class PlayerResponse
    {
        public Guid Id { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get; set; }
        public string Email { get;  set; }
        public string  Status { get;  set; }

        public static explicit operator PlayerResponse(Entities.Player entity)
        {
            return new PlayerResponse()
            {
                Id = entity.Id,
                Email = entity.Email.Address,
                FirstName = entity.Name.FirstName,
                LastName = entity.Name.LastName,
                Status = entity.Status.ToString()

            };
        }
    }
}
