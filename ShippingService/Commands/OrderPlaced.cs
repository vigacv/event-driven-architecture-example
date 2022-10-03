using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ShippingService.Commands
{
    public class OrderPlaced: IRequest<Unit>
    {
        public Guid OrderId { get; set; }
    }
}