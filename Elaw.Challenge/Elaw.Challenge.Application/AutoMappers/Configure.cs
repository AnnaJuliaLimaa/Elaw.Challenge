using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Elaw.Challenge.Application
{
    public static class Configure
    {
        public static void AutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(e =>
            {
                e.AddProfile(new DomainViewModel());
                e.AddProfile(new ViewModelDomain());
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
