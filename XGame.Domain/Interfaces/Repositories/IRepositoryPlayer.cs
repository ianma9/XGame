using System;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories.Base;

namespace XGame.Domain.Interfaces.Repositories
{
    public interface IRepositoryPlayer : IRepositoryBase<Player, Guid>
    {
    }
}
