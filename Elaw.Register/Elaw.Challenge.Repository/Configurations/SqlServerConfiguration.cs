using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace Elaw.Challenge.Extensions.Repository
{
    public static class SqlServerConfiguration
    {
        public static IServiceCollection ConfigureDbContext<T>(this IServiceCollection services, IConfiguration configuration, string pattern, bool tracking = true) where T : DbContext
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            var connection = configuration.GetConnectionString(pattern);

            if (string.IsNullOrEmpty(connection))
                throw new FileNotFoundException(Errors.ConfigNotFound);

            services.AddDbContext<T>(options =>
            {
                options.UseSqlServer(connection, sql => sql.EnableRetryOnFailure());

                if (!tracking)
                    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            }, ServiceLifetime.Transient);

            return services;
        }
        public static void ConfigureDbContextFactory<T>(this IServiceCollection services, IConfiguration configuration, ServiceLifetime lifetime = ServiceLifetime.Transient) where T : DbContext
        {
            services.AddDbContextFactory<T>(delegate (DbContextOptionsBuilder options)
            {
                options.EnableSensitiveDataLogging();

                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

                options.ConfigureWarnings(builder =>
                {
                    builder.Ignore(RelationalEventId.BoolWithDefaultWarning);
                    builder.Ignore(CoreEventId.PossibleIncorrectRequiredNavigationWithQueryFilterInteractionWarning);
                });

            },
                lifetime
            );
        }
    }
}