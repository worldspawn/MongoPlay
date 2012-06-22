using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MongoDB.Driver;
using Xunit;

namespace MongoPlay.Core.Tests.Config
{
    public class MongoModule
    {
        [Fact]
        public void AllServicesCanBeResolved()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<Core.Config.MongoModule>();

            var container = builder.Build();
            Assert.NotNull(container.Resolve<MongoServer>());
            Assert.NotNull(container.Resolve<MongoDatabase>());
        }
    }
}
