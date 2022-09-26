using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingService.Models
{
    public class OrderBill
    {
        public Guid OrderId { get; set; }
        public PaymentDetails PaymentDetails { get; set; }
        public bool IsPaid { get; set; }
    }
}