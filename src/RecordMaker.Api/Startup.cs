using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using RecordMaker.Core.Repositories;
using RecordMaker.Infrastructure.IoC;
using RecordMaker.Infrastructure.IoC.Modules;
using RecordMaker.Infrastructure.Mappers;
using RecordMaker.Infrastructure.Repositories;
using RecordMaker.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NLog.Web;
using RecordMaker.Infrastructure.Extensions;
using RecordMaker.Infrastructure.Settings;
using RecordMaker.Api.Framework;
using RecordMaker.Infrastructure.Mongo;

namespace RecordMaker.Api
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange:true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }
        public ILifetimeScope AutofacContainer { get; private set; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpClient();
            services.AddMemoryCache();
            services.AddJwtAuthorization();
            // services.AddLogging(builder =>
            // {
            //     builder.SetMinimumLevel(LogLevel.Trace);
            //     builder.AddNLog("nlog.config");
            // });
        } 
        
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ContainerModule(Configuration));
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            ILoggerFactory loggerFactory, IHostApplicationLifetime appLifetime)
        {
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseExceptionHandlerMiddleware();
            MongoConfiguration.Initialize();
            var generalSettings = app.ApplicationServices.GetService<GeneralSettings>();
            if (generalSettings.SeedData) 
            {
                var dataInitializer = app.ApplicationServices.GetService<IDataInitializer>();
                dataInitializer.SeedAsync();
            }
            
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}