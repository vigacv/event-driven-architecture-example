using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingService.Models;
using BillingService.Repository;
using MediatR;

namespace BillingService.Commands
{
    public class StorePaymentDetailsHandler : IRequestHandler<StorePaymentDetailsForOrder, Unit>
    {
        private readonly IBillingRepository _billingRepository;
        public StorePaymentDetailsHandler(IBillingRepository billingRepository)
        {
            _billingRepository = billingRepository;
        }

        public Task<Unit> Handle(StorePaymentDetailsForOrder request, CancellationToken cancellationToken)
        {
            _billingRepository.AddOrderBill(new OrderBill{
                OrderId = request.OrderId,
                PaymentDetails = request.PaymentDetails,
                IsPaid = false
            });
            return Task.FromResult(Unit.Value);
        }
    }
}