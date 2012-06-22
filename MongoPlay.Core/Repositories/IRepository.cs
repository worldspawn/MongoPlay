using System;
namespace MongoPlay.Core.Repositories
{
    public interface IRepository<TEntity>
     where TEntity : global::MongoPlay.Data.Entities.Entity
    {
        bool Any(global::System.Linq.Expressions.Expression<Func<TEntity, bool>> criteria);
        TEntity ById(Guid id);
        int Count(global::System.Linq.Expressions.Expression<Func<TEntity, bool>> criteria);
        TEntity Delete(TEntity entity);
        global::System.Collections.Generic.IEnumerable<TEntity> Find(global::System.Linq.Expressions.Expression<Func<TEntity, bool>> criteria, int skip = 0, int? take = null);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entityToUpdate);
    }
}
