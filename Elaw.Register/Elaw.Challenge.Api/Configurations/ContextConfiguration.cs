using Elaw.Challenge.Infra;
using Microsoft.EntityFrameworkCore;
using Elaw.Challenge.Extensions.Repository;

namespace Elaw.Challenge.Api
{
    public static class ContextConfiguration
    {
        public static WebApplicationBuilder AddContext(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var provider = builder.Configuration.CreateContext<LocalDbContext>("DefaultConnection");

            provider.Reset<LocalDbContext>();

            builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<LocalDbContext>());

            builder.Services.ConfigureDbContext<LocalDbContext>(builder.Configuration, "DefaultConnection");
            
            return builder;
        }
    }
}