using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Domain
{
    public class CustomerManager
    {
        protected IUnitOfWork uow;

        public CustomerManager(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public bool AddCustomer(Customer customer)
        {
            if(customer.Name.Length > 0 && customer.Address.Length > 10)
            {
                uow.Customers.Add(customer);
                Save();
                return true;
            }
            return false;
        }

        public Customer GetByID(int id)
        {
            Customer customer = uow.Customers.GetByID(id);
            if(customer != null)
                customer.Orders = uow.Orders.GetAllByCustomerID(id);
            return customer;
        }

        public List<Customer> GetAll()
        {
            List<Customer> list = uow.Customers.GetAll();
            foreach (Customer customer in list)
                customer.Orders = uow.Orders.GetAllByCustomerID(customer.ID);
            return list;
        }

        public void Remove(int id)
        {
            uow.Customers.Remove(id);
            Save();
        }

        public void RemoveAll()
        {
            uow.Customers.RemoveAll();
            Save();
        }

        public void Update(Customer customer)
        {
            uow.Customers.Update(customer);
            Save();
        }

        public void Save()
        {
            uow.Complete();
        }
    }
}
