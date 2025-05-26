using Microsoft.EntityFrameworkCore;

namespace Elaw.Challenge.Extensions.Repository
{
    public abstract class BaseContext<T> : DbContext where T : DbContext
    {
        public BaseContext(DbContextOptions<T> options) : base(options)
        {
            Database.SetCommandTimeout(1000);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            // Unicode
            builder.Properties<string>().AreUnicode(false);
            builder.Properties<List<string>>().AreUnicode(false);
            builder.Properties<Dictionary<string, string>>().AreUnicode(false);

            // Precisions
            builder.Properties<double>().HavePrecision(18, 2);
            builder.Properties<decimal>().HavePrecision(18, 2);

            base.ConfigureConventions(builder);
        }
    }
}