using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace BillingService.Commands
{
    public class StorePaymentDetailsHandler : IRequestHandler<StorePaymentDetailsForOrder, Unit>
    {
        public Task<Unit> Handle(StorePaymentDetailsForOrder request, CancellationToken cancellationToken)
        {
            return Unit.Task;
        }
    }
}