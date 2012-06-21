using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;

namespace MongoPlay.Web.Hubs
{
    [HubName("ToDo")]
    public class ToDoHub : Hub
    {
    }
}