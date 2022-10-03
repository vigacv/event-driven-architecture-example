using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Models
{
    public class OrderEvent
    {
        public string Type { get; set; }
        public Guid OrderId { get; set; }
    }
}