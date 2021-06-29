using System;
using System.Collections.Generic;

namespace Domain
{
      public class Product : Entity
    {
        private Product() { }

        public string Name { get; private set; }
        public string Type { get; private set; }
        public ICollection<ProductPackage> Containers { get; set; }

        public static Product Create(string name, string type)
        {
            var product = new Product { 
                Name = name,
                Type = type
            };

            return product;
        }
    }
}
