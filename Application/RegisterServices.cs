using FluentValidation;
using HicomInterview.Application.Interfaces;
using HicomInterview.Application.Services;
using Mapster;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RegisterServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<IAddValidator>(ServiceLifetime.Singleton);

            services.AddScoped<IWidgetService, WidgetService>();

            // Add all bespoke Mapster configurations
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly()); // add all "IRegister" Mappings to the service container

            return services;
        }
    }

    interface IAddValidator { }
}
