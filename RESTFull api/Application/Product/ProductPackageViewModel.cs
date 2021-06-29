using System;
using Domain;

namespace Application
{
    public class ProductPackageViewModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }        
        public int ProductPackageId { get; private set; }
    }
}