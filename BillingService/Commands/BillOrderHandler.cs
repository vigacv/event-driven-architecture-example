using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingService.Repository;
using MediatR;

namespace BillingService.Commands
{
    public class BillOrderHandler: IRequestHandler<BillOrder, Unit>
    {
        private readonly IBillingRepository _billingRepository;
        public BillOrderHandler(IBillingRepository billingRepository)
        {
            _billingRepository = billingRepository;
        }
        public Task<Unit> Handle(BillOrder request, CancellationToken cancellationToken)
        {
            var orderBill = _billingRepository.GetOrderBill(request.OrderId).Result;

            if(orderBill != null) orderBill.IsPaid = true;

            return Task.FromResult(Unit.Value);
        }
    }
}