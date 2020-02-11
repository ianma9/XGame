using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XGame.Domain.Entities
{
    public class MyGames
    {
        public Guid Id { get; set; }
        public GamePlatform GamePlatform { get; set; }
        public bool ToWish { get; set; }
        public DateTime WishDate { get; set; }
        public bool ToExchange { get; set; }
        public bool ToSale { get; set; }

    }
}
