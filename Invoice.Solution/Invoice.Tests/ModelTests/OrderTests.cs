using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Invoice.Models;
using System;

namespace Invoice.Tests
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
      DateTime date = new DateTime(2008,04,14);
      Order newOrder = new Order("testTitle", "testDescription", 10, date);
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }


    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      //Arrange
      string description = "Walk the dog.";
      DateTime date = new DateTime(2008,04,14);

      //Act
      Order newOrder = new Order("testTitle", description, 10, date);
      string result = newOrder.Description;

      //Assert
      Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      //Arrange
      string description = "Walk the dog.";
      DateTime date = new DateTime(2008,04,14);
      Order newOrder = new Order("testTitle", description, 10, date);
      

      //Act
      string updatedDescription = "Do the dishes";
      newOrder.Description = updatedDescription;
      string result = newOrder.Description;

      //Assert
      Assert.AreEqual(updatedDescription, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_OrderList()
    {
      // Arrange
      List<Order> newList = new List<Order> { };

      // Act
      List<Order> result = Order.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsOrders_OrderList()
    {
      //Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      DateTime date = new DateTime(2008,04,14);
      Order newOrder1 = new Order("testTitle1", description01, 10, date);
      Order newOrder2 = new Order("testTitle2", description02, 10, date);
      List<Order> newList = new List<Order> { newOrder1, newOrder2 };

      //Act
      List<Order> result = Order.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_OrdersInstantiateWithAnIdAndGetterReturn_Int()
    {
      string description = "walk the dog.";
      DateTime date = new DateTime(2008,04,14);
      Order newOrder = new Order("testTitle1", description, 10, date);
      int result = newOrder.Id;
      Assert.AreEqual(1,result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectItem_Order()
    {
      //Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      DateTime date = new DateTime(2008,04,14);
      Order newOrder1 = new Order("testTitle1", description01, 10, date);
      Order newOrder2 = new Order("testTitle2", description02, 10, date);

      //Act
      Order result = Order.Find(2);

      //Assert
      Assert.AreEqual(newOrder2, result);
    }
  }
}