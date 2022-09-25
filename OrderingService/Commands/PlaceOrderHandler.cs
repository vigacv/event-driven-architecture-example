using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using OrderingService.Events;

namespace OrderingService.Commands
{
    public class PlaceOrderHandler: IRequestHandler<PlaceOrder, Unit>
    {
        private readonly IPublisher _publisher;

        public PlaceOrderHandler(IPublisher publisher)
        {
            _publisher = publisher;
        }
        public async Task<Unit> Handle(PlaceOrder request, CancellationToken cancellationToken)
        {
            await _publisher.Publish(new OrderPlaced { OrderId = request.OrderId }, cancellationToken);
            return Unit.Value;
        }
    }
}