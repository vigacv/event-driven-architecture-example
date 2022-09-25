using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using OrderingService.Models;

namespace OrderingService.Commands
{
    public class CreateOrder: IRequest<Unit>
    {
        public Guid OrderId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}