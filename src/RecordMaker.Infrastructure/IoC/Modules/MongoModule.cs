using System.Reflection;
using Autofac;
using Microsoft.Extensions.Caching.Memory;
using MongoDB.Driver;
using RecordMaker.Core.Repositories;
using RecordMaker.Infrastructure.Mongo;
using RecordMaker.Infrastructure.Repositories;
using RecordMaker.Infrastructure.Repositories.Decorators;

namespace RecordMaker.Infrastructure.IoC.Modules
{
    public class MongoModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.Register((c, p) =>
            {
                var settings = c.Resolve<MongoSettings>();

                return new MongoClient(settings.ConnectionString);
            }).SingleInstance();

            builder.Register((c, p) =>
            {
                var client = c.Resolve<MongoClient>();
                var settings = c.Resolve<MongoSettings>();
                var database = client.GetDatabase(settings.Database);

                return database;
            }).As<IMongoDatabase>();
            
            var assembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x=>x.IsAssignableTo<IMongoRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

          
        }
    }
}