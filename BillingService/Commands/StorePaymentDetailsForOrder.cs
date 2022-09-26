using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingService.Models;
using MediatR;

namespace BillingService.Commands
{
    public class StorePaymentDetailsForOrder: IRequest<Unit>
    {
        public Guid OrderId { get; set; }
        public PaymentDetails PaymentDetails { get; set; }
    }
}