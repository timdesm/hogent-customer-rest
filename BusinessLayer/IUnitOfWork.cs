using BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IOrderRepository Orders { get; }
        int Complete();
    }
}
