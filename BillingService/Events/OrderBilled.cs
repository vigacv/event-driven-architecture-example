using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace BillingService.Events
{
    public class OrderBilled: INotification
    {
        public string Type => nameof(OrderBilled);
        public Guid OrderId { get; set; }   
    }
}