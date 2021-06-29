using System.Collections.Generic;
using System.Linq;
using Application;
using Domain;

namespace Persistence
{
    public static class ContainersData
    {        
         public static void Seed(IDbContext context) {
            if (context.Containers.Any())
            {
                return; // Db has been seeded;
            }
            
            var travelBag = Container.Create("Travel bag");
            travelBag.AddProducts(new List<Product> 
            {
                Product.Create("MacBook Pro", "Device"),
                Product.Create("Video camera", "Device"),
                Product.Create("Wallet", "Gadget")
            });

            var shelf = Container.Create("Shelf");
            shelf.AddProducts(new List<Product> 
            {
                Product.Create("MacBook Pro", "Device"),
                Product.Create("Steve Jobs", "Book"),
                Product.Create("Getting Things Done", "Book"),
            });


            var containerList = new Container[]
            {
                travelBag,
                shelf,
            };

            context.Containers.AddRange(containerList);
            context.SaveChanges();
        }

    }
}