using System;

namespace Domain
{
    public class ProductPackage : Entity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ContainerId { get; set; }
        public Container Container { get; set; }
    }
}
