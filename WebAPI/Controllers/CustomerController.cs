using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Domain;
using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public CustomerManager CustomerManager { get; set; }
        public OrderManager OrderManager { get; set; }

        public CustomerController()
        {
            CustomerManager = new CustomerManager(new UnitOfWork(new DataContext("gfd")));
        }


    }
}