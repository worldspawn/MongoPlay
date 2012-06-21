using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDB.Driver;
using MongoPlay.Web.Models;

namespace MongoPlay.Web.Controllers.Api
{
    public class ToDoController : ApiController
    {
        private readonly MongoDatabase _database;
        
        public ToDoController(MongoDatabase database)
        {
            _database = database;
        }

        public ToDoItem GetTodo(int id)
        {
            return new ToDoItem { Title = "Title", Item = "Something" };
        }

        public ToDoItem PostToDo(ToDoItem toDoItem)
        {
            var todoItems = _database.GetCollection<ToDoItem>("todo");
            var x = todoItems.Insert(toDoItem);
            
        }
    }
}
