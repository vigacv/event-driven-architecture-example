using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace OrderingService.Commands
{
    public class PlaceOrder: IRequest<Unit>
    {
        public Guid OrderId { get; set; }
    }
}