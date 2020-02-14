using System;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Infra.Persistence.Repositories.Base;

namespace XGame.Infra.Persistence.Repositories
{
    public class RepositoryPlayer : RepositoryBase<Player, Guid>, IRepositoryPlayer
    {
        protected readonly XGameDataContext _context;

        public RepositoryPlayer(XGameDataContext context) :base(context)
        {
            _context = context;
        }
    }
}
