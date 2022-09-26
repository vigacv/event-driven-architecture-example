using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace BillingService.Commands
{
    public class BillOrderHandler: IRequestHandler<BillOrder, Unit>
    {
        public Task<Unit> Handle(BillOrder request, CancellationToken cancellationToken)
        {
            return Unit.Task;
        }
    }
}