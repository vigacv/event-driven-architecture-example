using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingService.Models
{
    public class ShoppingCartItem
    {
        public string Id { get; set; }
        public string ShoppingCartId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}