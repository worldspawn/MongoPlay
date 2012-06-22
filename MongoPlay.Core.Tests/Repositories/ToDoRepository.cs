using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoPlay.Data.Entities;
using MongoPlay.Data.Repositories;
using Xunit;

namespace MongoPlay.Core.Tests.Repositories
{
    public class ToDoRepository
    {
        [Fact]
        public void CanCreateRepository()
        {
            using (var database = new MongoDbTest())
            {
                var repository = new Repository<ToDoItem>(database.Database);
            }
        }

        [Fact]
        public void CanInsert()
        {
            using (var database = new MongoDbTest())
            {
                var repository = new Repository<ToDoItem>(database.Database);

                var item = new ToDoItem() { Item = "Item", Title = "Title" };
                item = repository.Insert(item);

                Assert.NotNull(item);
            }
        }

        [Fact]
        public void CanUpdate()
        {
            using (var database = new MongoDbTest())
            {
                var repository = new Repository<ToDoItem>(database.Database);

                var item = new ToDoItem() { Item = "Item", Title = "Title" };
                item = repository.Insert(item);

                Assert.NotNull(item);

                item.Title = "Changed";
                repository.Update(item);

                item = repository.ById(item.Id);
                Assert.Equal("Changed", item.Title);
            }
        }

        [Fact]
        public void CanDelete()
        {
            using (var database = new MongoDbTest())
            {
                var repository = new Repository<ToDoItem>(database.Database);

                var item = new ToDoItem() { Item = "Item", Title = "Title" };
                item = repository.Insert(item);

                Assert.NotNull(item);

                Assert.NotNull(repository.Delete(item));

                Assert.Null(repository.ById(item.Id));
            }
        }

        [Fact]
        public void CanFind()
        {
            using (var database = new MongoDbTest())
            {
                var repository = new Repository<ToDoItem>(database.Database);

                var item = new ToDoItem() { Item = "Item", Title = "Title" };
                item = repository.Insert(item);

                Assert.NotNull(item);

                var result = repository.Find(e => e.Title == "Title");
                Assert.NotNull(result);
                Assert.Single(result);

                result = repository.Find(e => e.Title == "test");
                Assert.NotNull(result);
                Assert.Empty(result);
            }
        }

        [Fact]
        public void CanSkipAndTake()
        {
            using (var database = new MongoDbTest())
            {
                var repository = new Repository<ToDoItem>(database.Database);

                var item = new ToDoItem() { Item = "Item", Title = "Title" };
                item = repository.Insert(item);

                Assert.NotNull(item);

                var result = repository.Find(e => e.Title == "Title");
                Assert.NotNull(result);
                Assert.Single(result);

                result = repository.Find(e => e.Title == "test");
                Assert.NotNull(result);
                Assert.Empty(result);
            }
        }

        [Fact]
        public void CanCount()
        {
            using (var database = new MongoDbTest())
            {
                var repository = new Repository<ToDoItem>(database.Database);

                var item = new ToDoItem() { Item = "Item", Title = "Title" };
                item = repository.Insert(item);

                Assert.NotNull(item);

                Assert.Equal(1, repository.Count(e => e.Title == "Title"));
                Assert.Equal(0, repository.Count(e => e.Title == "test"));
            }
        }

        [Fact]
        public void CanAny()
        {
            using (var database = new MongoDbTest())
            {
                var repository = new Repository<ToDoItem>(database.Database);

                var item = new ToDoItem() { Item = "Item", Title = "Title" };
                item = repository.Insert(item);

                Assert.NotNull(item);

                Assert.True(repository.Any(e => e.Title == "Title"));
                Assert.False(repository.Any(e => e.Title == "test"));
            }
        }
    }
}
