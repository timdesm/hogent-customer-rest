using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Domain
{
    public class CustomerManager
    {
        private IUnitOfWork uow;

        public CustomerManager(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void AddCustomer(Customer customer)
        {
            uow.Customers.Add(customer);
        }

        


    }
}
