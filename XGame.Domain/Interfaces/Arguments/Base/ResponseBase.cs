using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGame.Domain.Entities;

namespace XGame.Domain.Interfaces.Arguments.Base
{
    public class ResponseBase
    {
        public string Message { get; set; }

        public ResponseBase()
        {
            Message = "Successfull";
        }

        public static explicit operator ResponseBase(Game entity)
        {
            return new ResponseBase()
            {
                Message = "Successfull"
            };
        }
    }
}
