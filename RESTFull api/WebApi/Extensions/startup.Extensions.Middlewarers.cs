using Microsoft.AspNetCore.Builder;

namespace WebApi
{
    public static partial class StartupExtensions
    {
         public static IApplicationBuilder AddMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
            
            return app;
        }
    }
}