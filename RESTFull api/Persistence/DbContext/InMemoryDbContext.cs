using Microsoft.EntityFrameworkCore;
using Domain;
using Application;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;

namespace Persistence
{
    public class InMemoryDbContext : DbContext, ISqlDbContext
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Container> Containers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}