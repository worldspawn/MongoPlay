using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoPlay.Data.Entities
{
    public class ToDoItem : Entity
    {
        public ToDoItem() { }
        public ToDoItem(string title, string item) { }
        public string Title { get; set; }
        public string Item { get; set; }
    }
}
