using System;
using System.Collections.Generic;

namespace Domain
{
    public class Container : Entity
    {
        private Container() { }

        public string Name { get; private set; }

        public ICollection<ProductPackage> Products { get; set; }

        public static Container Create(string name)
        {
            var container = new Container { 
                Name = name
            };

            return container;
        }
    }
}
