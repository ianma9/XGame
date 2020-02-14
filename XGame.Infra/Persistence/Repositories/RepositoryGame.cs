using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Repositories.Base;
using XGame.Infra.Persistence.Repositories.Base;

namespace XGame.Infra.Persistence.Repositories
{
    public class RepositoryGame : RepositoryBase<Game, Guid>, IRepositoryGame
    {
        protected readonly XGameDataContext _context;
        public RepositoryGame(XGameDataContext context) : base(context)
        {
            _context = context;
        }
    }
}
