using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using OrderingService.Models;

namespace OrderingService.Commands
{
    public class GetOrders : IRequest<List<Order>>
    {
    }
}