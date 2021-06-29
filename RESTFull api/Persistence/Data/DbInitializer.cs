using Application;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public static class DbInitializer
    {        
        public static void Initialize(IDbContext context)
        {
            context.Database.Migrate();
            context.Database.EnsureCreated();
        }
    }
}