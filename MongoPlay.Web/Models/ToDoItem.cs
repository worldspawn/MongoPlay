using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoPlay.Web.Models
{
    public class ToDoItem
    {
        public ToDoItem() { }
        public ToDoItem(Data.Entities.ToDoItem toDoItem)
        {
            Id = toDoItem.Id;
            Title = toDoItem.Title;
            Item = toDoItem.Item;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Item { get; set; }
    }
}