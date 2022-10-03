using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingService.Events;
using BillingService.Repository;
using MediatR;

namespace BillingService.Commands
{
    public class BillOrderHandler: IRequestHandler<BillOrder, Unit>
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IPublisher _publisher;
        public BillOrderHandler(IBillingRepository billingRepository, IPublisher publisher)
        {
            _billingRepository = billingRepository;
            _publisher = publisher;
        }
        public async Task<Unit> Handle(BillOrder request, CancellationToken cancellationToken)
        {
            var orderBill = _billingRepository.GetOrderBill(request.OrderId).Result;

            if(orderBill != null) orderBill.IsPaid = true;

            await _publisher.Publish(new OrderBilled
            {
                OrderId = request.OrderId
            });

            return Unit.Value;
        }
    }
}