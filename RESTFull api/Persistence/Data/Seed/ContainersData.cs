using System.Linq;
using Application;
using Domain;

namespace Persistence
{
    public static class ContainersData
    {        
         public static void Seed(ISqlDbContext context) {
            if (context.Containers.Any())
            {
                return; // Db has been seeded;
            }

            var containerList = new Container[]
            {
                Container.Create("Container 1"),
                Container.Create("Container 2"),
            };

            context.Containers.AddRange(containerList);
            context.SaveChanges();
        }

    }
}