using System;

namespace XGame.Domain.Arguments.Game
{
    public class AddGameResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        public static explicit operator AddGameResponse(Entities.Game entitiy)
        {
            return new AddGameResponse()
            {
                Id = entitiy.Id,
                Message = "Successfull"
            };
        }
    }
}
