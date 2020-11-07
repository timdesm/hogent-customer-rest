using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Models
{
    public class Customer
    {
        public Customer() { }

        public Customer(string name, string address)
        {
            this.Name = name;
            this.Address = address;
        }

        public Customer(int id, string name, string address)
        {
            this.ID = id;
            this.Name = name;
            this.Address = address;
        }

        [Required]
        public int ID { get; set; }
        [Required]
        public String Name { get; set; }
        [Required,MinLength(10)]
        public String Address { get; set; }
        public List<Order> Orders { get { return _OrderList; } set { _OrderList = value; } }
        private List<Order> _OrderList;
    }
}
