using BusinessLayer.Models;
using BusinessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DataLayer.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        protected DataContext context;
        
        public CustomerRepository(DataContext context)
        {
            this.context = context;
        }

        public void Add(Customer customer)
        {
            context.Customers.Add(customer);
        }

        public List<Customer> GetAll()
        {
            return context.Customers.ToList();
        }

        public Customer GetByID(int id)
        {
            return context.Customers.Where(x => x.ID == id).SingleOrDefault();
        }

        public void Remove(int id)
        {
            context.Customers.Remove(GetByID(id));
        }

        public void RemoveAll()
        {
            context.Customers.RemoveRange(context.Customers);
        }

        public void Update(Customer customer)
        {
            context.Update(customer);
        }
    }
}
