using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}