using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Domain;
using BusinessLayer.Models;
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
            CustomerManager = new CustomerManager(new UnitOfWork(new DataContext(Program.mode)));
            OrderManager = new OrderManager(new UnitOfWork(new DataContext(Program.mode)));
        }

        // Get all customers
        [HttpGet]
        public List<Customer> Get()
        {
            try
            {
                return CustomerManager.GetAll();
            }
            catch { }
            Response.StatusCode = 400;
            return null;
        }
        
        // Get customer
        [HttpGet("{id:int}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            Customer customer = CustomerManager.GetByID(id);
            if (customer != null)
                return customer;
            return NotFound("Customer not found");
        }

        // Create new customer
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            if(CustomerManager.AddCustomer(customer))
                return CreatedAtAction(nameof(GetCustomer), new { id = customer.ID }, customer);
            return BadRequest("Invalid arguments");
        }

        // Delete customer if no orders exist
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            if(CustomerManager.GetByID(id) != null)
            {
                if(OrderManager.GetAllByCustomerID(id).Count() <= 0)
                {
                    CustomerManager.Remove(id);
                    return Ok("Customer succesfully deleted");
                }
                return BadRequest("Orders still linked to customer");
            }
            return BadRequest("Customer not found");
        }

        // Update customer
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Customer customer)
        {
            Customer c = CustomerManager.GetByID(id);
            if(c != null)
            {
                if (customer.Name.Length >= 1 && customer.Address.Length >= 10)
                {
                    c.Name = customer.Name;
                    c.Address = customer.Address;
                    CustomerManager.Update(c);
                    return Ok(c);
                }
                return NotFound("Invalid arguments");
            }
            return NotFound("Customer not found");
        }

        // Get all order from customer
        [HttpGet("{id:int}/orders")]
        public ActionResult<List<Order>> GetOrders(int id)
        {
            Customer customer = CustomerManager.GetByID(id);
            if (customer != null)
                return OrderManager.GetAllByCustomerID(id);
            return NotFound("Customer not found");
        }

        // Delete customer orders
        [HttpDelete("{id:int}/orders")]
        public ActionResult DeleteOrders(int id)
        {
            Customer customer = CustomerManager.GetByID(id);
            if (customer != null)
            {
                foreach(Order order in OrderManager.GetAllByCustomerID(id))
                {
                    OrderManager.Remove(order.ID);
                }
                return Ok("Orders succesfully deleted");
            }
            return NotFound("Customer not found");
        }
    }
}