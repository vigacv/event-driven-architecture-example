using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace OrderingService.Commands
{
    public class CreateOrderHandler : IRequestHandler<CreateOrder, Unit>
    {
        public Task<Unit> Handle(CreateOrder request, CancellationToken cancellationToken)
        {
            return Unit.Task;
        }
    }
}