using Model.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Abstract.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntityBase, new()
    {
        TEntity First(Expression<Func<TEntity, bool>> filter);
        TEntity Find(Expression<Func<TEntity, bool>> filter);
        TEntity Last(Expression<Func<TEntity, bool>> filter);
        TEntity Max();

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        bool Any(Expression<Func<TEntity, bool>> filter = null);
        int Count(Expression<Func<TEntity, bool>> filter = null);

        IQueryable<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> selector);
        IQueryable<TResult> Select<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector);

        IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity SoftDelete(TEntity entity);
        TEntity UndoSoftDelete(TEntity entity);
        bool Delete(TEntity entity);
    }
}
