using Microsoft.VisualStudio.TestTools.UnitTesting;
using Invoice.Models;
using System.Collections.Generic;
using System;

namespace Catalogue.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {

    public void Dispose()
    {
      Vendor.ClearAll();
    }
    
    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      Vendor newVendor = new Vendor("test vendor", "test detail");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Test Vendor";
      string detail = "Test Detail";
      Vendor newVendor = new Vendor(name, detail);

      //Act
      string result = newVendor.Name;

      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetName_ReturnsDetail_String()
    {
      //Arrange
      string name = "Test name";
      string detail = "Test detail";

      Vendor newVendor = new Vendor(name, detail);

      //Act
      string result = newVendor.Detail;

      //Assert
      Assert.AreEqual(detail, result);
    }

    [TestMethod]
    public void GetId_ReturnsVendorId_Int()
    {
      //Arrange
      string name = "Test Vendor";
      string detail = "Test detail";

      Vendor newVendor = new Vendor(name, detail);

      //Act
      int result = newVendor.Id;

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllVendorObjects_VendorList()
    {
      //Arrange
      string name01 = "Work";
      string name02 = "School";
      string detail01 = "Test detail";
      string detail02 = "Test detail";
      Vendor newVendor1 = new Vendor(name01, detail01);
      Vendor newVendor2 = new Vendor(name02, detail02);
      List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };

      //Act
      List<Vendor> result = Vendor.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectVendor_Vendor()
    {
      //Arrange
      string name01 = "Work";
      string name02 = "School";
      string detail01 = "Test detail";
      string detail02 = "Test detail";
      Vendor newVendor1 = new Vendor(name01, detail01);
      Vendor newVendor2 = new Vendor(name02, detail02);

      //Act
      Vendor result = Vendor.Find(2);

      //Assert
      Assert.AreEqual(newVendor2, result);
    }

    [TestMethod]
    public void AddItem_AssociatesItemWithCategory_ItemList()
    {
      //Arrange
      string description = "Walk the dog.";
      DateTime date = new DateTime(2008,04,14);
      Order newOrder = new Order("test title", description, 10, date);
      List<Order> newList = new List<Order> { newOrder };
      string name = "Work";
      string detail = "Detail";
      Vendor newVendor = new Vendor(name, detail);
      newVendor.AddOrder(newOrder);

      //Act
      List<Order> result = newVendor.Orders;

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
  }
}
