using System.Reflection;
using Autofac;
using Microsoft.Extensions.Configuration;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Settings;
using RecordMaker.Infrastructure.Extensions;
using RecordMaker.Infrastructure.Mongo;

namespace RecordMaker.Infrastructure.IoC.Modules
{
    public class SettingsModule: Autofac.Module
    {

        private readonly IConfiguration _configuration;
        
        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>())
                    .SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>())
                   .SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<MongoSettings>())
                .SingleInstance();
        }
    }
}