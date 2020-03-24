using System.Reflection;
using Autofac;
using RecordMaker.Core.Repositories;
using RecordMaker.Infrastructure.Services;

namespace RecordMaker.Infrastructure.IoC.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModule)
                .GetTypeInfo()
                .Assembly;
            
            builder.RegisterAssemblyTypes(assembly)
                    .Where(x=>x.IsAssignableTo<IService>())
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

            builder.RegisterType<Encrypter>()
                    .As<IEncrypter>()
                    .SingleInstance();

            builder.RegisterType<JwtHandler>()
                .As<IJwtHandler>()
                .SingleInstance();
        }
    }
    //TODO: Create Provider which gives possible names to Tables? Maybe available season? Maybe available referee? Some kind of a Dictionary
}