using BusinessLayer;
using BusinessLayer.Domain;
using BusinessLayer.Models;
using DataLayer;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceTests
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void Test_Customers_Add()
        {
            CustomerManager cm = new CustomerManager(new UnitOfWork(new DataContext("development")));
            cm.RemoveAll();
            int amount = cm.GetAll().Count;
            cm.AddCustomer(new Customer("Tim", "Azaleastraat 57, 9940 Evergem"));
            int newAmount = cm.GetAll().Count;
            Assert.AreEqual(newAmount, amount + 1);
            cm.RemoveAll();
        }

        [TestMethod]
        public void Test_Customers_Get()
        {
            CustomerManager cm = new CustomerManager(new UnitOfWork(new DataContext("development")));
            cm.RemoveAll();
            cm.AddCustomer(new Customer("Tim", "Azaleastraat 57, 9940 Evergem"));
            int id = cm.GetAll().Last().ID;
            Customer c = cm.GetByID(id);
            Assert.AreEqual(c.ID, id);
            Assert.AreEqual(c.Name, "Tim");
            Assert.AreEqual(c.Address, "Azaleastraat 57, 9940 Evergem");
            cm.RemoveAll();
        }

        [TestMethod]
        public void Test_Customers_GetAll()
        {
            CustomerManager cm = new CustomerManager(new UnitOfWork(new DataContext("development")));
            cm.RemoveAll();
            cm.AddCustomer(new Customer("Tim", "Azaleastraat 57, 9940 Evergem"));
            cm.AddCustomer(new Customer("Tim", "Azaleastraat 57, 9940 Evergem"));
            cm.AddCustomer(new Customer("Tim", "Azaleastraat 57, 9940 Evergem"));
            Assert.AreEqual(cm.GetAll().Count, 3);
            cm.RemoveAll();
        }

        [TestMethod]
        public void Test_Customers_RemoveByID()
        {
            CustomerManager cm = new CustomerManager(new UnitOfWork(new DataContext("development")));
            cm.RemoveAll();
            cm.AddCustomer(new Customer("Tim", "Azaleastraat 57, 9940 Evergem"));
            Customer c = cm.GetAll().Last();
            int amount = cm.GetAll().Count;
            cm.Remove(c.ID);
            int newAmount = cm.GetAll().Count;
            Assert.AreEqual(newAmount, amount - 1);
            cm.RemoveAll();
        }

        [TestMethod]
        public void Test_Customers_RemoveAll()
        {
            CustomerManager cm = new CustomerManager(new UnitOfWork(new DataContext("development")));
            cm.AddCustomer(new Customer("Tim", "Azaleastraat 57, 9940 Evergem"));
            cm.RemoveAll();
            int newAmount = cm.GetAll().Count;
            Assert.AreEqual(newAmount, 0);
            cm.RemoveAll();
        }

        [TestMethod]
        public void Test_Customers_Update()
        {
            CustomerManager cm = new CustomerManager(new UnitOfWork(new DataContext("development")));
            cm.RemoveAll();
            cm.AddCustomer(new Customer("Tim", "Azaleastraat 57, 9940 Evergem"));
            Customer c = cm.GetAll().Last();
            Assert.AreEqual(c.Name, "Tim");
            Assert.AreEqual(c.Address, "Azaleastraat 57, 9940 Evergem");
            c.Name = "Jolien";
            c.Address = "Wolffaertshoflaan 3, 2630 Aartselaar";
            cm.Update(c);
            Customer c2 = cm.GetByID(c.ID);
            Assert.AreEqual(c2.Name, "Jolien");
            Assert.AreEqual(c2.Address, "Wolffaertshoflaan 3, 2630 Aartselaar");
            cm.RemoveAll();
        }
    }
}
