using System;
using System.Collections;
using System.Collections.Generic;
using XGame.Domain.Arguments.Player;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories.Base;

namespace XGame.Domain.Interfaces.Repositories
{
    public interface IRepositoryPlayer : IRepositoryBase<Player, Guid>
    {

    }
}
