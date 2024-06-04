using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Reflection;
using MapsterMapper;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IMapper, Mapper>();

            return services;
        }
    }
}
