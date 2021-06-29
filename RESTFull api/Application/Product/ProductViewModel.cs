using System;
using Domain;

namespace Application
{
    public class ProductViewModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
    }
}