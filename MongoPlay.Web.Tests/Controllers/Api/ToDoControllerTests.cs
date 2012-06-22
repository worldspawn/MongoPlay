using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using MongoPlay.Core.Repositories;
using MongoPlay.Data.Entities;
using MongoPlay.Web.Controllers.Api;
using MongoPlay.Web.Tests.Common;
using NSubstitute;
using Xunit;

namespace MongoPlay.Web.Tests.Controllers.Api
{
    public class ToDoControllerTests
    {
        [Fact]
        public void CanPostToDoItem()
        {
            var todoRepository = TestHelpers.CreateMockRepository<ToDoItem>();
            var controller = new ToDoController(todoRepository);
            var item = new MongoPlay.Web.Models.ToDoItem() { Title = "TestTitle", Item = "TestItem" };
            var savedItem = controller.PostToDo(item);

            Assert.NotNull(savedItem);
        }

        [Fact]
        public void CanGetToDoItem()
        {
            var todoRepository = TestHelpers.CreateMockRepository<ToDoItem>();
            var controller = new ToDoController(todoRepository);

            var item = controller.PostToDo(new Models.ToDoItem() { Title = "TestTitle", Item = "TestItem" });
            var getItem = controller.GetTodo(item.Id);

            Assert.NotNull(getItem);
            Assert.Equal(item.Id, getItem.Id);
        }

        [Fact]
        public void GetToDoItemThrows404WhenIdNotFound()
        {
            var todoRepository = TestHelpers.CreateMockRepository<ToDoItem>();
            var controller = new ToDoController(todoRepository);

            var id = Guid.NewGuid();
            Assert.Throws<HttpResponseException>(() => controller.GetTodo(id));
        }
    }
}
