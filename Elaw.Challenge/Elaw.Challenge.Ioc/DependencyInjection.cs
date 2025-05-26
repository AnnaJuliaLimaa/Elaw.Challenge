using FluentValidation;
using Elaw.Challenge.Domain;
using Elaw.Challenge.Application;
using Elaw.Challenge.Application.Validators;
using Microsoft.Extensions.DependencyInjection;
using Elaw.Challenge.Extensions;


namespace Elaw.Challenge.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection Inject(this IServiceCollection services)
        {
           
            // Injector -> Fluent Validator
            services.AddScoped<IValidator<CustomerViewModel>, CustomerValidator>();

            // Injector -> Auto Mapper
            services.Configure();

            // Injector -> Application
            services.AddScoped(typeof(ICustomerApplication), typeof(CustomerApplication));

            // Injector -> Repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Injector -> Domain
            services.AddScoped(typeof(ICustomerService), typeof(CustomerService));

            return services;
        }
        
    }
}