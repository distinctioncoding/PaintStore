using System;
using FluentAssertions;
using PaintStore.Models;

namespace PaintStore.Tests;

public class OrderModelTests
{
    [Fact]
    public void TotalPrice_WhenNoPaintProducts_ShouldBeZero()
    {
        //Arrange
        var order = new Order();
  
        //Act & Assert
        order.TotalPrice.Should().Be(0);
    }

    [Fact]
    //With One product, price should be XXXX
    public void TotalPrice_WithOneProduct_ReturnsTheProductPrice()
    {
        //Arrange
        var order = new Order();
        order.PaintProducts.Add(new PaintProduct("Dulux", 19.99m));

        //Act & Assert
        order.TotalPrice.Should().Be(19.99m);
    }
    
}
