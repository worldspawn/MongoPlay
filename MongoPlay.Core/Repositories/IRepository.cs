using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace MongoPlay.Core.Repositories
{
    public interface IRepository<TEntity>
     where TEntity : global::MongoPlay.Data.Entities.Entity
    {
        bool Any(Expression<Func<TEntity, bool>> criteria);
        TEntity ById(Guid id);
        int Count(Expression<Func<TEntity, bool>> criteria);
        TEntity Delete(TEntity entity);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> criteria);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, object>> orderBy, int skip = 0, int? take = null);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entityToUpdate);
    }
}
