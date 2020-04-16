using System.Reflection;
using Autofac;
using RecordMaker.Core.Repositories;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Repositories.Decorators;

namespace RecordMaker.Infrastructure.IoC.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x=>x.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            
            builder.RegisterDecorator(typeof(CachingDecorator), typeof(IUserRepository));
        }
    }
}