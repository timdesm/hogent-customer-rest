using BusinessLayer.Domain;
using BusinessLayer.Models;
using DataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceTests
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void Test_Orders_Add()
        {
            CustomerManager cm = new CustomerManager(new UnitOfWork(new DataContext("development")));
            OrderManager om = new OrderManager(new UnitOfWork(new DataContext("development")));
            om.RemoveAll();
            cm.RemoveAll();
            cm.AddCustomer(new Customer("Tim", "Azaleastraat 57, 9940 Evergem"));
            Customer c = cm.GetAll().Last();
            int amount = om.GetAll().Count;
            om.Add(new Order(c, Product.DUVEL, 5));
            int newAmount = om.GetAll().Count;
            Assert.AreEqual(newAmount, amount + 1);
            om.RemoveAll();
            cm.RemoveAll();
        }

        [TestMethod]
        public void Test_Orders_Get()
        {
            CustomerManager cm = new CustomerManager(new UnitOfWork(new DataContext("development")));
            OrderManager om = new OrderManager(new UnitOfWork(new DataContext("development")));
            om.RemoveAll();
            cm.RemoveAll();
            cm.AddCustomer(new Customer("Tim", "Azaleastraat 57, 9940 Evergem"));
            Customer c = cm.GetAll().Last();
            om.Add(new Order(c, Product.DUVEL, 5));
            int id = om.GetAll().Last().ID;
            Order order = om.GetByID(id);
            Assert.AreEqual(order.ID, id);
            Assert.AreEqual(order.CustomerID, c.ID);
            Assert.AreEqual(order.Product, Product.DUVEL);
            Assert.AreEqual(order.Amount, 5);
            om.RemoveAll();
            cm.RemoveAll();
        }

        [TestMethod]
        public void Test_Orders_GetAll()
        {
            CustomerManager cm = new CustomerManager(new UnitOfWork(new DataContext("development")));
            OrderManager om = new OrderManager(new UnitOfWork(new DataContext("development")));
            om.RemoveAll();
            cm.RemoveAll();
            cm.AddCustomer(new Customer("Tim", "Azaleastraat 57, 9940 Evergem"));
            Customer c = cm.GetAll().Last();
            om.Add(new Order(c, Product.DUVEL, 5));
            om.Add(new Order(c, Product.DUVEL, 5));
            om.Add(new Order(c, Product.DUVEL, 5));
            Assert.AreEqual(om.GetAll().Count, 3);
            om.RemoveAll();
            cm.RemoveAll();
        }

        [TestMethod]
        public void Test_Orders_RemoveByID()
        {
            CustomerManager cm = new CustomerManager(new UnitOfWork(new DataContext("development")));
            OrderManager om = new OrderManager(new UnitOfWork(new DataContext("development")));
            om.RemoveAll();
            cm.RemoveAll();
            cm.AddCustomer(new Customer("Tim", "Azaleastraat 57, 9940 Evergem"));
            Customer c = cm.GetAll().Last();
            om.Add(new Order(c, Product.DUVEL, 5));
            int id = om.GetAll().Last().ID;
            int amount = om.GetAll().Count;
            om.Remove(id);
            int newAmount = om.GetAll().Count;
            Assert.AreEqual(newAmount, amount - 1);
            om.RemoveAll();
            cm.RemoveAll();
        }

        [TestMethod]
        public void Test_Orders_RemoveAll()
        {
            CustomerManager cm = new CustomerManager(new UnitOfWork(new DataContext("development")));
            OrderManager om = new OrderManager(new UnitOfWork(new DataContext("development")));
            om.RemoveAll();
            cm.RemoveAll();
            cm.AddCustomer(new Customer("Tim", "Azaleastraat 57, 9940 Evergem"));
            Customer c = cm.GetAll().Last();
            om.Add(new Order(c, Product.DUVEL, 5));
            om.RemoveAll();
            int newAmount = om.GetAll().Count;
            Assert.AreEqual(newAmount, 0);
            om.RemoveAll();
            cm.RemoveAll();
        }

        [TestMethod]
        public void Test_Orders_Update()
        {
            CustomerManager cm = new CustomerManager(new UnitOfWork(new DataContext("development")));
            OrderManager om = new OrderManager(new UnitOfWork(new DataContext("development")));
            om.RemoveAll();
            cm.RemoveAll();
            cm.AddCustomer(new Customer("Tim", "Azaleastraat 57, 9940 Evergem"));
            Customer c = cm.GetAll().Last();
            om.Add(new Order(c, Product.DUVEL, 5));
            Order order = om.GetAll().Last();
            Assert.AreEqual(order.CustomerID, c.ID);
            Assert.AreEqual(order.Product, Product.DUVEL);
            Assert.AreEqual(order.Amount, 5);
            cm.AddCustomer(new Customer("Jolien", "Wolffaertshoflaan 3, 2630 Aartselaar"));
            int c2_id = cm.GetAll().Last().ID;
            order.CustomerID = c2_id;
            order.Product = Product.LEFFE;
            order.Amount = 3;
            om.Update(order);
            Order o2 = om.GetByID(order.ID);
            Assert.AreEqual(o2.CustomerID, c2_id);
            Assert.AreEqual(o2.Product, Product.LEFFE);
            Assert.AreEqual(o2.Amount, 3);
            om.RemoveAll();
        }
    }
}
