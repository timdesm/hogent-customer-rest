using BusinessLayer;
using BusinessLayer.Repository;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext context;

        public UnitOfWork(DataContext context)
        {
            this.context = context;
            Customers = new CustomerRepository();
            Orders = new OrderRepository();
        }

        public ICustomerRepository Customers { get; private set; }
        public IOrderRepository Orders { get; private set; }

        public int Complete()
        {
            try
            {
                return context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
