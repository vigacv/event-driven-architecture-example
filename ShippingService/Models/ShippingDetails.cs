using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Models
{
    public class ShippingDetails
    {
        public Guid OrderId { get; set; }
        public Address ShippingAddress { get; set; }
    }
}