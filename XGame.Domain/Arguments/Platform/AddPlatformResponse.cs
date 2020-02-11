using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XGame.Domain.Arguments.Platform
{
    public class AddPlatformResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}
