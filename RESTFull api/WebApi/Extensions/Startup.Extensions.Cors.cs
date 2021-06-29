using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi
{
    public static partial class StartupExtensions
    {
        public static IServiceCollection AddAllOriginsCors(this IServiceCollection services)
        {
            services.AddCors(options => { 
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            return services;
        }

        public static IApplicationBuilder UseAllOriginsCors(this IApplicationBuilder app)
        {
            app.UseCors("AllowAllOrigins");
            
            return app;
        }
    }
}