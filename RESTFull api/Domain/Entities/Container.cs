using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Container : Entity
    {
        private Container() { }

        public string Name { get; private set; }

        public List<ProductPackage> Products { get ; private set; }

        public static Container Create(string name)
        {
            var container = new Container { 
                Name = name,
                Products = new List<ProductPackage>()
            };

            return container;
        }

        public Container AddProducts(IEnumerable<Product> products)
        {            
            if (products == null || !products.Any())
                return this;

            Products.AddRange(products.Select(p => new ProductPackage { Product = p, Container = this }));

            return this;
        }

        public Container RemoveProducts(IEnumerable<ProductPackage> products)
        {            
            if (products == null || !products.Any())
                return this;
                
            Products.RemoveAll(x => products.Select(p => p.Id).Contains(x.Id));

            return this;
        }
    }
}
