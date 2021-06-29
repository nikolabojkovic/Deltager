using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Domain;
using Application;
using System.Threading.Tasks;
using System.Threading;

namespace Persistence
{
    public class SqlDbContext : DbContext, ISqlDbContext
    {
        public DbSet<Container> Containers { get; set; }

        public SqlDbContext(DbContextOptions<SqlDbContext> options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            modelBuilder.UseEntityTypeConfiguration(typeof(ContainerConfiguration).Assembly);
            RegisterEntities(modelBuilder);
        }

        private void RegisterEntities(ModelBuilder modelBuilder)
        {
            MethodInfo entityMethod = typeof(ModelBuilder).GetMethods()
                                                          .First(m => m.Name == "Entity" 
                                                                   && m.IsGenericMethod);

            var entityTypes = Assembly.GetAssembly(typeof(Container))
                .GetTypes()
                .Where(x => x.IsSubclassOf(typeof(Entity)) 
                         && !x.IsAbstract);

            foreach (var type in entityTypes)
            {
                entityMethod.MakeGenericMethod(type)
                            .Invoke(modelBuilder, new object[] { });
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

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