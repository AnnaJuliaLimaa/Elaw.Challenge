using Elaw.Challenge.Application;
using Elaw.Challenge.Domain;
using Elaw.Challenge.Extensions;
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
            var configuration = new ConfigurationBuilder().AddJsonFile(Values.Settings).Build();

            var services = new ServiceCollection();

            var dbContextProvider = configuration.CreateContext<LocalDbContext>(Values.Connection);
            dbContextProvider.Reset<LocalDbContext>();

            services.AddScoped<DbContext>(provider => provider.GetRequiredService<LocalDbContext>());
            services.ConfigureDbContext<LocalDbContext>(configuration, Values.Connection);

            // Injetores
            services.Configure();
            services.AddScoped(typeof(ICustomerApplication), typeof(CustomerApplication));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(ICustomerService), typeof(CustomerService));

            var provider = services.BuildServiceProvider();

            _application = provider.GetRequiredService<ICustomerApplication>();

            Customer = new CustomerViewModel();
            Customer.SetPhone("21994882658");
            Customer.SetEmail("annxa@gmail.com");
            Customer.SetName("anna");
            Customer.AddAddress(new AddressViewModel { City = "Rio de Janeiro", Number = "121", Street = "Rua Embaú", State = "RJ", ZipCode = "21555000", Id = Guid.Parse("6a602eb6-f49c-44f7-a781-ca9bc62ba80a") });
        }
    }
}