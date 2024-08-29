using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Reflection;
using MapsterMapper;
using MediatR;
using Application.Common.Behaviours;
using Autofac.Core;

namespace Application
{
    public static class DependencyInjection
    {/// <summary>
     /// Registers all validators from the current assembly using FluentValidation.
        ///Configures MediatR to register request/response handlers.
        ///Registers object mapping, I'm using Mapster here.
        ///Adds a custom pipeline behavior (ValidationBehavior) for handling validation in MediatR requests.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IMapper, Mapper>();
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
