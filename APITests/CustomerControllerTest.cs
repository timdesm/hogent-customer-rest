using BusinessLayer.Domain;
using BusinessLayer.Models;
using DataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Controllers;

namespace APITests
{
    [TestClass]
    public class CustomerControllerTest
    {
        [TestMethod]
        public void Test_Customer_Get()
        {
            CustomerManager cm = new CustomerManager(new UnitOfWork(new DataContext("development")));
            cm.RemoveAll();
            cm.AddCustomer(new Customer("Tim", "Azaleastraat 57, 9940 Evergem"));
            var controller = new CustomerController("development");
            var result = controller.Get() as List<Customer>;
            Assert.AreEqual(cm.GetAll().Count, result.Count);
            cm.RemoveAll();
        }
    }
}
