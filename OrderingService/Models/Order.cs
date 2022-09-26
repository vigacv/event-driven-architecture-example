using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingService.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public bool IsPlaced { get; set; }
    }
}