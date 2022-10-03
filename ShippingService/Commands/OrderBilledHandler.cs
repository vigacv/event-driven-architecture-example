using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ShippingService.Repository;

namespace ShippingService.Commands
{
    public class OrderBilledHandler : IRequestHandler<OrderBilled, Unit>
    {
        private readonly IShippingRepository _shippingRepository;

        public OrderBilledHandler(IShippingRepository shippingRepository)
        {
            _shippingRepository = shippingRepository;
        }

        public async Task<Unit> Handle(OrderBilled request, CancellationToken cancellationToken)
        {
            var shippingDetails = await _shippingRepository.GetShippingDetails(request.OrderId);

            if(shippingDetails == null) return Unit.Value;

            shippingDetails.SetBilled();

            return Unit.Value;
        }
    }
}