using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ShippingService.Repository;

namespace ShippingService.Commands
{
    public class OrderPlacedHandler : IRequestHandler<OrderPlaced, Unit>
    {
        private readonly IShippingRepository _shippingRepository;

        public OrderPlacedHandler(IShippingRepository shippingRepository)
        {
            _shippingRepository = shippingRepository;
        }

        public async Task<Unit> Handle(OrderPlaced request, CancellationToken cancellationToken)
        {
            var shippingDetails = await _shippingRepository.GetShippingDetails(request.OrderId);

            if(shippingDetails == null) return Unit.Value;

            shippingDetails.SetOrdered();
            
            return Unit.Value;
        }
    }
}