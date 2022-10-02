using MediatR;
using ShippingService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Commands
{
    public class StoreShippingDetailsHandler: IRequestHandler<StoreShippingDetailsForOrder>
    {
        private readonly IShippingRepository _shippingRepository;

        public StoreShippingDetailsHandler(IShippingRepository shippingRepository)
        {
            _shippingRepository = shippingRepository;
        }
        public async Task<Unit> Handle(StoreShippingDetailsForOrder request, CancellationToken cancellationToken)
        {
            await _shippingRepository.StoreShippingDetails(request.ShippingDetails);
            return Unit.Value;
        }
    }
}