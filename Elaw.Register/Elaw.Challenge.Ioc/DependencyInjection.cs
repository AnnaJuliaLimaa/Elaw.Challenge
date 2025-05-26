using FluentValidation;
using Microsoft.AspNetCore.Mvc.Versioning;
using Elaw.Challenge.Domain;
using Elaw.Challenge.Application;
using Elaw.Challenge.Extensions.Repository;
using Elaw.Challenge.Application.Validators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;


namespace Elaw.Challenge.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection Inject(this IServiceCollection services)
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

            // Injector -> Fluent Validator
            services.AddScoped<IValidator<CustomerViewModel>, CustomerValidator>();

            // Injector -> Auto Mapper
            services.AutoMapper();

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