namespace XGame.Domain.Arguments.Player
{
    public class PlayerAuthenticationResponse
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }

        public static explicit operator PlayerAuthenticationResponse(Entities.Player entity)
        {
            return new PlayerAuthenticationResponse()
            {
                Email = entity.Email.Address,
                FirstName = entity.Name.FirstName,
                Status = (int) entity.Status
            };
        }
    }
}
