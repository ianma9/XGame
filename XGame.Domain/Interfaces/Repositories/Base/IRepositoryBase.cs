using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace XGame.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity, TId>
        where TEntity : class
        where TId : struct
    {
        IQueryable<TEntity> ListBy(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        IQueryable<TEntity> ListAndOrderBy<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> order, bool ascending = true, params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity GetBy(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] includeProperties);

        bool Exist(Func<TEntity, bool> where);

        IQueryable<TEntity> List(params Expression<Func<TEntity, object>>[] includeProperties);

        IQueryable<TEntity> OrderedListBy<TKey>(Expression<Func<TEntity, TKey>> order, bool ascending = true, params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity GetById(TId id, params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity AddEntity(TEntity entity);

        TEntity Edit(TEntity entity);

        void Remove(TEntity entity);

        IEnumerable<TEntity> AddList(IEnumerable<TEntity> entity);
    }
}
