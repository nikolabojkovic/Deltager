using System.Collections.Generic;

namespace Application
{
    public class ContainerViewModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public IEnumerable<ProductPackageViewModel> Products { get; set; }

    }
}