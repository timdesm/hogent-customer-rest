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
        protected DataContext context;

        public UnitOfWork(DataContext context)
        {
            this.context = context;
            Customers = new CustomerRepository(context);
            Orders = new OrderRepository(context);
        }

        public ICustomerRepository Customers { get; private set; }
        public IOrderRepository Orders { get; private set; }

        public int Complete()
        {
            try
            {
                return context.SaveChanges();
            }
            catch
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
