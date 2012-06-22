using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoPlay.Core.Repositories;
using MongoPlay.Web.Models;

namespace MongoPlay.Web.Controllers.Api
{
    public class ToDoController : ApiController
    {
        private readonly IRepository<Data.Entities.ToDoItem> _todoRepository;

        public ToDoController(IRepository<Data.Entities.ToDoItem> todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public ToDoItem GetTodo(Guid id)
        {
            var entity = _todoRepository.ById(id);
            if (entity == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return new Models.ToDoItem(_todoRepository.ById(id));
        }

        public ToDoItem PostToDo(ToDoItem toDoItem)
        {
            var entity = new Data.Entities.ToDoItem(toDoItem.Item, toDoItem.Title);
            entity = _todoRepository.Insert(entity);

            return new ToDoItem(entity);
        }

        public ToDoItem PutToDo(ToDoItem toDoItem)
        {
            var entity = _todoRepository.ById(toDoItem.Id);
            if (entity == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            entity.Title = toDoItem.Title;
            entity.Item = toDoItem.Item;

            _todoRepository.Update(entity);

            return toDoItem;
        }
    }
}
