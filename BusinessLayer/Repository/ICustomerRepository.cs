using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Repository
{
    public interface ICustomerRepository
    {
        public void Add(Customer customer);
        public List<Customer> GetAll();
        public Customer GetByID(int id);
        public void Remove(int id);
        public void RemoveAll();
        public void Update(Customer customer);
    }
}
