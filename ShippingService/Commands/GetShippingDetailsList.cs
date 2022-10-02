using MediatR;
using ShippingService.Models;

namespace ShippingService.Commands
{
    public class GetShippingDetailsList: IRequest<List<ShippingDetails>>
    {
    }
}
