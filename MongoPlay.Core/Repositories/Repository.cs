using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using FluentMongo.Linq;
using MongoDB.Driver.Builders;

namespace MongoPlay.Data.Repositories
{
    public class Repository<TEntity> : MongoPlay.Core.Repositories.IRepository<TEntity> where TEntity : MongoPlay.Data.Entities.Entity
    {
        private readonly MongoDatabase _mongoDatabase;
        private readonly MongoCollection<TEntity> _collection;
        
        public Repository(MongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
            _collection = mongoDatabase.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public TEntity ById(Guid id)
        {
            return _collection.AsQueryable()
                .FirstOrDefault(e => e.Id == id);
        }

        public TEntity Insert(TEntity entity)
        {
            if (entity.Id == default(Guid))
                entity.Id = Guid.NewGuid();

            _collection.Insert(entity);
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            var query = Query.EQ("id", entity.Id);
            _collection.Remove(query, RemoveFlags.Single);
            return entity;
        }

        public IEnumerable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> criteria, int skip = 0, int? take = null)
        {
            var result = _collection.AsQueryable().Where(criteria);
            if (skip > 0)
                result = result.Skip(skip);
            if (take.HasValue)
                result = result.Take(take.Value);

            return result;
        }

        public bool Any(System.Linq.Expressions.Expression<Func<TEntity, bool>> criteria)
        {
            return _collection.AsQueryable().Any(criteria);
        }

        public int Count(System.Linq.Expressions.Expression<Func<TEntity, bool>> criteria)
        {
            return _collection.AsQueryable().Count(criteria);
        }

        public TEntity Update(TEntity entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
