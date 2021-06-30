using Application;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;

namespace WebApi
{
    public static partial class StartupExtensions
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(new Assembly[] { Assembly.Load("Application") });
            
            services.AddTransient(typeof(IValidator<CreateProductCommand>), typeof(CreateProductCommandValidator));

            return services;
        }
    }
}