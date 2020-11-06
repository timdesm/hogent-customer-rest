using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Models
{
    public class Order
    {
        public Order() { }

        public Order(Customer customer, Product product, int amount)
        {
            this.CustomerID = customer.ID;
            this.Product = product;
            this.Amount = amount;
        }

        public Order(int id, Customer customer, Product product, int amount)
        {
            this.ID = id;
            this.CustomerID = customer.ID;
            this.Product = product;
            this.Amount = amount;
        }

        [Required]
        public int ID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        [Required]
        public Product Product { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter an amount of 1 or more")]
        public int Amount { get; set; }
    }
}
