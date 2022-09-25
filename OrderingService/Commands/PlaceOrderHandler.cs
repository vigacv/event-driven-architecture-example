using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace OrderingService.Commands
{
    public class PlaceOrderHandler: IRequestHandler<PlaceOrder, Unit>
    {
        public Task<Unit> Handle(PlaceOrder request, CancellationToken cancellationToken)
        {
            return Unit.Task;
        }
    }
}