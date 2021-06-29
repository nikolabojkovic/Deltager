using System;
using Xunit;
using FluentAssertions;
using Domain;

namespace UnitTests
{
    public class SheduleAppointmentTest
    {
        [Fact]
        public void Create_Appointment_SchedulePendingAppoinment()
        {
            // Arrange
            var productName = "MacBook Pro";
            var productType = "Device";        

            // Act
            var product = Product.Create(productName, productType);

            // Assert
            product.Name.Should().Be(productName);
            product.Type.Should().Be(productType);
        }
    }
}
