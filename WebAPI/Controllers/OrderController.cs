using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Domain;
using BusinessLayer.Models;
using DataLayer;
using DataLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public CustomerManager CustomerManager { get; set; }
        public OrderManager OrderManager { get; set; }

        public OrderController(string db = "production")
        {
            CustomerManager = new CustomerManager(new UnitOfWork(new DataContext(db)));
            OrderManager = new OrderManager(new UnitOfWork(new DataContext(db)));
        }

        // Get all orders
        [HttpGet]
        public List<Order> Get()
        {
            try
            {
                return OrderManager.GetAll();
            }
            catch { }
            Response.StatusCode = 400;
            return null;
        }

        // Get order
        [HttpGet("{id:int}")]
        public ActionResult<Order> GetOrder(int id)
        {
            Order order = OrderManager.GetByID(id);
            if (order != null)
                return order;
            return NotFound("Order not found");
        }

        // Create new order
        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
        {
            if (OrderManager.Add(order))
                return CreatedAtAction(nameof(GetOrder), new { id = order.ID }, order);
            return BadRequest("Invalid arguments");
        }

        // Delete order
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            if(OrderManager.GetByID(id) != null)
            {
                OrderManager.Remove(id);
                return Ok("Order succesfully deleted");
            }
            return BadRequest("Order not found");
        }

        // Update order
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Order order)
        {
            Order o = OrderManager.GetByID(id);
            if (o != null)
            {
                if(order.Amount >= 1 && CustomerManager.GetByID(order.CustomerID) != null)
                {
                    o.Product = order.Product;
                    o.Amount = order.Amount;
                    o.CustomerID = order.CustomerID;
                    OrderManager.Update(o);
                    return Ok(o);
                }
                return NotFound("Invalid arguments");
            }
            return NotFound("Order not found");
        }
    }
}