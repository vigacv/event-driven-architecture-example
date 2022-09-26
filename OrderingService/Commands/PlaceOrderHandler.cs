using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using OrderingService.Events;
using OrderingService.Repository;

namespace OrderingService.Commands
{
    public class PlaceOrderHandler : IRequestHandler<PlaceOrder, Unit>
    {
        private readonly IPublisher _publisher;
        private readonly IOrderRepository _orderRepository;

        public PlaceOrderHandler(IPublisher publisher, IOrderRepository orderRepository)
        {
            _publisher = publisher;
            _orderRepository = orderRepository;
        }
        public async Task<Unit> Handle(PlaceOrder request, CancellationToken cancellationToken)
        {
            var order = _orderRepository.GetOrder(request.OrderId).Result;
            if (order != null)
            {
                order.IsPlaced = true;
                await _publisher.Publish(new OrderPlaced { OrderId = request.OrderId }, cancellationToken);
            }
            return Unit.Value;
        }
    }
}