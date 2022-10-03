using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ShippingService.Commands
{
    public class OrderBilled: IRequest
    {
        public Guid OrderId { get; set; }
    }
}