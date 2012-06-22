using System;
using System.Collections.Generic;
using System.Linq;
using MongoPlay.Core.Repositories;
using MongoPlay.Data.Entities;
using NSubstitute;

namespace MongoPlay.Web.Tests.Common
{
    public static class TestHelpers
    {
        public static IRepository<TEntity> CreateMockRepository<TEntity>() where TEntity : Entity
        {
            var list = new List<TEntity>();
            var repository = Substitute.For<IRepository<TEntity>>();

            repository.Any(Arg.Any<System.Linq.Expressions.Expression<Func<TEntity, bool>>>()).Returns(context => list.AsQueryable().Any(context.Arg<System.Linq.Expressions.Expression<Func<TEntity, bool>>>()));

            repository.ById(Arg.Any<Guid>())
                .Returns(context => list.AsQueryable().FirstOrDefault(e => e.Id == context.Arg<Guid>()));

            repository.Count(Arg.Any<System.Linq.Expressions.Expression<Func<TEntity, bool>>>()).Returns(context => list.AsQueryable().Count(context.Arg<System.Linq.Expressions.Expression<Func<TEntity, bool>>>()));

            repository.Delete(Arg.Any<TEntity>())
                .Returns((context) => { list.Remove(list.First(e => e.Id == context.Arg<TEntity>().Id)); return context.Arg<TEntity>(); });

            repository.Find(Arg.Any<System.Linq.Expressions.Expression<Func<TEntity, bool>>>()).Returns(context => list.AsQueryable().Where(context.Arg<System.Linq.Expressions.Expression<Func<TEntity, bool>>>()));
            
            repository.Find(Arg.Any<System.Linq.Expressions.Expression<Func<TEntity, bool>>>(), Arg.Any<System.Linq.Expressions.Expression<Func<TEntity, object>>>(), Arg.Any<int>(), Arg.Any<int?>()).Returns(context => list.AsQueryable().Where(context.Arg<System.Linq.Expressions.Expression<Func<TEntity, bool>>>()));

            repository.Insert(Arg.Any<TEntity>())
                .Returns((context) => { 
                    var item = context.Arg<TEntity>();
                    if (item.Id == default(Guid)) 
                        item.Id = Guid.NewGuid();
                    list.Add(item); return item;
                });

            repository.Update(Arg.Any<TEntity>())
                .Returns((context) =>
                {
                    var newItem = context.Arg<TEntity>();
                    var oldItem = list.First(x => x.Id == newItem.Id);

                    list.Remove(oldItem);
                    list.Add(newItem);
                    return newItem;
                });


            return repository;
        }
    }
}
