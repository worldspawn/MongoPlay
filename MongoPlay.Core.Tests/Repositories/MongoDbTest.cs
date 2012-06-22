using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace MongoPlay.Core.Tests.Repositories
{
    public class MongoDbTest : IDisposable
    {
        private readonly MongoDatabase _database;

        public MongoDatabase Database
        {
            get { return _database; }
        }

        public MongoDbTest()
        {
            var mongoServer = MongoServer.Create();
            _database = mongoServer.GetDatabase(Guid.NewGuid().ToString());
        }

        public void Dispose()
        {
            var server = _database.Server;
            server.DropDatabase(_database.Name);
            server.Disconnect();
        }
    }
}
