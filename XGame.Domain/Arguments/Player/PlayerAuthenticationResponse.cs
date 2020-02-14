using System;

namespace XGame.Domain.Arguments.Player
{
    public class PlayerAuthenticationResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }

        public static explicit operator PlayerAuthenticationResponse(Entities.Player entity)
        {
            return new PlayerAuthenticationResponse()
            {
                Id = entity.Id,
                Email = entity.Email.Address,
                FirstName = entity.Name.FirstName,
                Status = (int) entity.Status
            };
        }
    }
}
