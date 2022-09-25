using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingService.Models
{
    public class ShoppingCart
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public List<ShoppingCartItem> Items { get; set; }
    }
}