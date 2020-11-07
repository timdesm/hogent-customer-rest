using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Domain
{
    public class OrderManager
    {
        protected IUnitOfWork uow;

        public OrderManager(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public bool Add(Order order)
        {
            if (order.Amount >= 1 && uow.Customers.GetByID(order.CustomerID) != null)
            {
                uow.Orders.Add(order);
                Save();
                return true;
            }
            return false;
        }

        public Order GetByID(int id)
        {
            return uow.Orders.GetByID(id);
        }

        public List<Order> GetAll()
        {
            List<Order> list = uow.Orders.GetAll();
            return list;
        }

        public List<Order> GetAllByCustomerID(int customer_ID)
        {
            return uow.Orders.GetAllByCustomerID(customer_ID);
        }

        public void Remove(int id)
        {
            uow.Orders.Remove(id);
            Save();
        }

        public void RemoveAll()
        {
            uow.Orders.RemoveAll();
            Save();
        }

        public void Update(Order order)
        {
            uow.Orders.Update(order);
            Save();
        }

        public void Save()
        {
            uow.Complete();
        }
    }
}
