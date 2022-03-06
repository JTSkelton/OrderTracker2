using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using OrderTracker.Models;
using System;

namespace OrderTracker.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {

    public void Dispose()
    {
      Order.ClearAll();
    }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("test",1,2);
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      string description = "More Bread";
      Order newOrder = new Order(description,1,2);
      string result = newOrder.Description;
      Assert.AreEqual(description, result);
    }

     [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      string description = "Bread";
      Order newOrder = new Order(description,1,2);
      string updatedDescription = "More Bread";
      newOrder.Description = updatedDescription;
      string result = newOrder.Description;
      Assert.AreEqual(updatedDescription, result);
    }

      [TestMethod]
    public void GetPastery_ReturnsPastery_Int()
    {
      int pastery = 1;
      Order newOrder = new Order("More Bread",pastery,2);
      int result = newOrder.Pastery;
      Assert.AreEqual(pastery, result);
    }

     [TestMethod]
    public void SetPastery_SetPastery_Int()
    {
      int pastery = 1;
      Order newOrder = new Order("description",pastery,2);
      int updatedPastery = 3;
      newOrder.Pastery = updatedPastery;
      int result = newOrder.Pastery;
      Assert.AreEqual(updatedPastery, result);
    }
  }
}