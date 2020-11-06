using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Repository
{
    public interface IOrderRepository
    {
        public void Add(Order order);
        public List<Order> GetAll();
        public Order GetByID(int id);
        public void Remove(int id);
        public void RemoveAll();
        public void Update(Order order);
        public List<Order> GetAllByCustomerID(int customer_ID);
    }
}
