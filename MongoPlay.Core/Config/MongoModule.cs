using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using MongoDB.Driver;

namespace MongoPlay.Core.Config
{
    public class MongoModule : Autofac.Module
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            builder.Register((context)=>{
                return MongoServer.Create();
            }).SingleInstance();

            builder.Register((context)=>{
                var mongoServer = context.Resolve<MongoServer>();
                return mongoServer.GetDatabase("todolist");
            }).SingleInstance();

            base.Load(builder);
        }
    }
}