using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingService.Models;
using BillingService.Repository;
using MediatR;

namespace BillingService.Commands
{
    public class GetOrderBillsHandler: IRequestHandler<GetOrderBills, List<OrderBill>>
    {
        private readonly IBillingRepository _billingRepository;
        public GetOrderBillsHandler(IBillingRepository billingRepository)
        {
            _billingRepository = billingRepository;
        }

        public Task<List<OrderBill>> Handle(GetOrderBills request, CancellationToken cancellationToken)
        {
            return _billingRepository.GetOrderBills();
        }
    }
}