using Autofac;
using Microsoft.Extensions.Configuration;
using RecordMaker.Infrastructure.Extensions;
using RecordMaker.Infrastructure.IoC.Modules;
using RecordMaker.Infrastructure.Mappers;
using RecordMaker.Infrastructure.Settings;

namespace RecordMaker.Infrastructure.IoC
{
    public class ContainerModule: Autofac.Module
    {
        
        private readonly IConfiguration _configuration;
        
        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize())
                .SingleInstance();
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule(new SettingsModule(_configuration));
        }
    }
}