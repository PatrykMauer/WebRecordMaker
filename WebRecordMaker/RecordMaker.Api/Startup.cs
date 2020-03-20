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

namespace RecordMaker.Api
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }
        public ILifetimeScope AutofacContainer { get; private set; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddAuthorization();
            services.AddControllers();
            services.AddHttpClient();

        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ContainerModule(Configuration));
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            app.UseRouting();

            // Endpoint aware middleware. 
            // Middleware can use metadata from the matched endpoint.
            app.UseAuthorization();

            // Execute the matched endpoint.
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
          //  appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}