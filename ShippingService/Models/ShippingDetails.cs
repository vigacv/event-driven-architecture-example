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
        public bool IsOrdered { get; private set; } = false;
        public bool IsBilled { get; private set; } = false;
        public bool IsShipped { get; private set; } = false;

        public void SetBilled(){
            IsBilled = true;
            IsShipped = IsBilled && IsOrdered;
        }

        public void SetOrdered(){
            IsOrdered = true;
            IsShipped = IsBilled && IsOrdered;
        }
    }
}