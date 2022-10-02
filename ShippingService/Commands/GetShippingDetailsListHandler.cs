using MediatR;
using ShippingService.Models;
using ShippingService.Repository;

namespace ShippingService.Commands
{
    public class GetShippingDetailsListHandler : IRequestHandler<GetShippingDetailsList, List<ShippingDetails>>
    {
        private readonly IShippingRepository _shippingRepository;

        public GetShippingDetailsListHandler(IShippingRepository shippingRepository)
        {
            _shippingRepository = shippingRepository;
        }

        public async Task<List<ShippingDetails>> Handle(GetShippingDetailsList request, CancellationToken cancellationToken)
        {
            return await _shippingRepository.GetAllShippingDetails();
        }
    }
}
