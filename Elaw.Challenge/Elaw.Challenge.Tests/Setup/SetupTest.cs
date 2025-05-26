using Elaw.Challenge.Application;
using Elaw.Challenge.Domain;
using Elaw.Challenge.Extensions.Repository;
using Elaw.Challenge.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Elaw.Challenge.Tests
{
    public class SetupTest
    {
        public CustomerViewModel Customer { get; set; }
        public ICustomerApplication _application { get; set; }
        public IRepository<Customer> _repository { get; set; }

        [SetUp]
        public void Setup()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var services = new ServiceCollection();

            var dbContextProvider = configuration.CreateContext<LocalDbContext>("DefaultConnection");
            dbContextProvider.Reset<LocalDbContext>();

            services.AddScoped<DbContext>(provider => provider.GetRequiredService<LocalDbContext>());
            services.ConfigureDbContext<LocalDbContext>(configuration, "DefaultConnection");

            // Injetores
            services.AutoMapper();
            services.AddScoped(typeof(ICustomerApplication), typeof(CustomerApplication));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(ICustomerService), typeof(CustomerService));

            var provider = services.BuildServiceProvider();

            _application = provider.GetRequiredService<ICustomerApplication>();
            Customer = new CustomerViewModel();
            Customer.AddCustomer("Anna", "anna@gmail.com", "21994242884", new AddressViewModel { City = "Rio de Janeiro", Number = "2134", Street = "Rua Embaú", State = "RJ", ZipCode = "21535000", Id = Guid.Parse("6a602eb6-f49c-44f7-a781-ca9bc62ba80a") });
        }
    }
}