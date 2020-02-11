using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XGame.Domain.Arguments.Player
{
    public class PlayerAuthenticationRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
