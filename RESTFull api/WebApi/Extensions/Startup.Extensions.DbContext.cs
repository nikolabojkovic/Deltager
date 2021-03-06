using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Application;
using Persistence;

namespace WebApi
{
    public static partial class SartupExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var dbConnectionString = configuration.GetConnectionString("SqlConnection");
            services.AddDbContext<SqlDbContext>(opt =>
                    opt.UseMySql(dbConnectionString, 
                        ServerVersion.AutoDetect(dbConnectionString),
                        x => x.MigrationsAssembly("Persistence")));

            services.AddDbContext<InMemoryDbContext>(opt => opt.UseInMemoryDatabase("InMemoryDatabase"));

            if (configuration.GetValue<bool>("UseInMemoryDb"))
                services.AddScoped<IDbContext, InMemoryDbContext>();
            else
                services.AddScoped<IDbContext, SqlDbContext>();

            return services;
        }
    }
}