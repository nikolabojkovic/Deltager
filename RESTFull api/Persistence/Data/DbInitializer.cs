using Application;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public static class DbInitializer
    {        
        public static void Initialize(ISqlDbContext context)
        {
            context.Database.Migrate();
            context.Database.EnsureCreated();
        }
    }
}