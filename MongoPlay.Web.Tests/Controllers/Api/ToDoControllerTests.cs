using System;
using System.Web.Http;
using MongoPlay.Data.Entities;
using MongoPlay.Web.Controllers.Api;
using MongoPlay.Web.Tests.Common;
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

        [Fact]
        public void UpdateWorks()
        {
            var todoRepository = TestHelpers.CreateMockRepository<ToDoItem>();
            var controller = new ToDoController(todoRepository);

            var item = new Web.Models.ToDoItem();
            item.Title = "Test Title";
            item.Item = "Test Item";
            item = controller.PostToDo(item);

            item.Title = "Modded Title";
            item = controller.PutToDo(item);

            Assert.NotNull(item);
            Assert.Equal("Modded Title", item.Title);
        }

        [Fact]
        public void DeleteWorks()
        {
            var todoRepository = TestHelpers.CreateMockRepository<ToDoItem>();
            var controller = new ToDoController(todoRepository);

            var item = new Web.Models.ToDoItem();
            item.Title = "Test Title";
            item.Item = "Test Item";
            item = controller.PostToDo(item);

            item = controller.DeleteToDo(item.Id);
            Assert.NotNull(item);
        }

        [Fact]
        public void DeleteThrows404WhenIdNotFound()
        {
            var todoRepository = TestHelpers.CreateMockRepository<ToDoItem>();
            var controller = new ToDoController(todoRepository);

            var id = Guid.NewGuid();
            Assert.Throws<HttpResponseException>(() => controller.DeleteToDo(id));
        }

        [Fact]
        public void UpdateThrows404WhenIdNotFound()
        {
            var todoRepository = TestHelpers.CreateMockRepository<ToDoItem>();
            var controller = new ToDoController(todoRepository);

            var item = new Web.Models.ToDoItem();
            Assert.Throws<HttpResponseException>(() => controller.PutToDo(item));
        }
    }
}
