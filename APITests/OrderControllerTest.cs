using BusinessLayer.Domain;
using BusinessLayer.Models;
using DataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAPI.Controllers;

namespace APITests
{
    [TestClass]
    public class OrderControllerTest
    {
        [TestMethod]
        public void Test_Order_Get()
        {
            CustomerManager cm = new CustomerManager(new UnitOfWork(new DataContext("development")));
            OrderManager om = new OrderManager(new UnitOfWork(new DataContext("development")));
            om.RemoveAll();
            cm.RemoveAll();
            cm.AddCustomer(new Customer("Tim", "Azaleastraat 57, 9940 Evergem"));
            Customer c = cm.GetAll().Last();
            om.Add(new Order(c, Product.DUVEL, 5));
            var controller = new OrderController("development");
            var result = controller.Get() as List<Order>;
            Assert.AreEqual(om.GetAll().Count, result.Count);
            om.RemoveAll();
            cm.RemoveAll();
        }
    }
}
