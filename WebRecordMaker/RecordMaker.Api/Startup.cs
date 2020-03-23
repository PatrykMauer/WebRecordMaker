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
using RecordMaker.Infrastructure.Extensions;
using RecordMaker.Infrastructure.Settings;

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
            services.AddAuthorization(x=>x.AddPolicy("MustBeObserver",
                p=>p.RequireRole("observer")));
            services.AddControllers();
            services.AddHttpClient();
            services.AddMemoryCache();
            var key = Configuration
                .GetSettings<JwtSettings>().Key;

            var issuer = Configuration
                .GetSettings<JwtSettings>().Issuer;

            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                        ValidIssuer = issuer,
                        ValidateAudience = false
                    };
                });
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
            
            var generalSettings = app.ApplicationServices.GetService<GeneralSettings>();
            if (generalSettings.SeedData)
            {
                var dataInitializer = app.ApplicationServices.GetService<IDataInitializer>();
                dataInitializer.SeedAsync();
            }
            // Execute the matched endpoint.
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
          //  appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}