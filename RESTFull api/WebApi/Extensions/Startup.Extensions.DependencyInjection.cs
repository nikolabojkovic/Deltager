using Microsoft.Extensions.DependencyInjection;
using Application;
using Domain;

namespace WebApi
{
    public static partial class StartupExtensions
    {
        public static IServiceCollection AddDepenedencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();

            return services;
        }
    }
}