using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RecordMaker.Infrastructure.Settings;

namespace RecordMaker.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions    
    {
        public static void AddJwtAuthorization(this IServiceCollection services)
        {
            services.AddJwt();
            services.AddAuthorization(x =>
            {
                x.AddPolicy("observer", p => p.RequireRole("observer"));
                x.AddPolicy("referee", p => p.RequireRole("referee"));
                x.AddPolicy("admin", p => p.RequireRole("admin"));
            });
        }
        public static void AddJwt(this IServiceCollection services)
        {
            IConfiguration configuration;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }
            
            var settings = configuration
                .GetSettings<JwtSettings>();

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
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Key)),
                        ValidIssuer = settings.Issuer,
                        ValidateAudience = false
                    };
                });
        }
    }
}