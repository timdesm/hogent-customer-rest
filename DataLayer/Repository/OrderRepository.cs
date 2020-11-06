using BusinessLayer.Models;
using BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private DataContext context;

        public OrderRepository(DataContext context)
        {
            this.context = context;
        }

        public void Add(Order order)
        {
            context.Orders.Add(order);
        }

        public List<Order> GetAll()
        {
            return context.Orders.ToList();
        }

        public Order GetByID(int id)
        {
            return context.Orders.Where(x => x.ID == id).SingleOrDefault();
        }

        public void Remove(int id)
        {
            context.Orders.Remove(GetByID(id));
        }

        public void RemoveAll()
        {
            context.Orders.RemoveRange(context.Orders);
        }

        public void Update(Order order)
        {
            context.Update(order);
        }

        public List<Order> GetAllByCustomerID(int customer_ID)
        {
            return context.Orders.Where(x => x.CustomerID == customer_ID).ToList();
        }
    }
}
