using Microsoft.EntityFrameworkCore;
using Elaw.Challenge.Domain;

namespace Elaw.Challenge.Infra
{
    public class LocalDbContext : DbContext
    {
        public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerMap());
            builder.ApplyConfiguration(new AddressMap());

            base.OnModelCreating(builder);
        }
    }
}
