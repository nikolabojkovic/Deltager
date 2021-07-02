using Xunit;
using FluentAssertions;
using Domain;
using System.Linq;
using System.Collections.Generic;

namespace UnitTests
{
    public class ContainerTest
    {
        [Fact]
        public void Create_Container_ShouldCreateContainer()
        {
            // Arrange
            var containerName = "Container 1";              

            // Act
            var container = Container.Create(containerName);

            // Assert
            container.Name.Should().Be(containerName);
            container.Products.Count().Should().Be(0);
        }

        [Fact]
        public void AddProducts_ToContainer_ShouldAddProductsToContainer()
        {
            // Arrange
            var containerName = "Container 1";    
            var container = Container.Create(containerName);  
            var products = new List<Product> 
            {
                Product.Create("MacBook Pro", "Laptop"),
                Product.Create("iPhobne 12", "Mobile")
            };       

            // Act
            container.AddProducts(products);

            // Assert
            container.Products.Count().Should().Be(2);
            var expectedProducts = container.Products.ToList();

            expectedProducts[0].Product.Name.Should().Be(products[0].Name);
            expectedProducts[1].Product.Name.Should().Be(products[1].Name);
        }
        [Fact]
        public void RemoveProducts_FromContainer_ShouldRemoveProductsFromContainer()
        {
            // Arrange
            var containerName = "Container 1";    
            var container = Container.Create(containerName);  
            var macBookPro = Product.Create("MacBook Pro", "Laptop");
            macBookPro.Id = 1;
            var iPhone12 =  Product.Create("iPhobne 12", "Mobile");
            iPhone12.Id = 2;
            var iPhone11 = Product.Create("iPhobne 11", "Mobile");
            iPhone11.Id = 3;

            var products = new List<Product> 
            {
                macBookPro,
                iPhone12,
                iPhone11
            };            
            container.AddProducts(products);
            var productPackage = container.Products.ToList();
            productPackage[0].Id = 1;
            productPackage[0].Id = 2;
            productPackage[0].Id = 3;

            // Act
            container.RemoveProducts(container.Products.Where(x => x.Product.Type == "Mobile"));

            // Assert
            container.Products.Count().Should().Be(1);
        }
    }
}
