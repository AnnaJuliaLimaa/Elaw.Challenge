using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Elaw.Challenge.Extensions.Repository;
using Elaw.Challenge.Infra;
using Microsoft.EntityFrameworkCore;

namespace Elaw.Challenge.Api.Configure
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureVersion(this IServiceCollection services)
        {
            // Injector -> Versioning
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader() // Versionamento via URL
                );
            });

            return services;
        }
        public static WebApplicationBuilder AddContext(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var provider = builder.Configuration.CreateContext<LocalDbContext>(Values.Connection);

            provider.Reset<LocalDbContext>();

            builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<LocalDbContext>());

            builder.Services.ConfigureDbContext<LocalDbContext>(builder.Configuration, Values.Connection);

            return builder;
        }
    }
}
