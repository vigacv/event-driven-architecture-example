using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using OrderingService.Models;
using OrderingService.Repository;

namespace OrderingService.Commands
{
    public class CreateOrderHandler : IRequestHandler<CreateOrder, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        public CreateOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public Task<Unit> Handle(CreateOrder request, CancellationToken cancellationToken)
        {
            _orderRepository.AddOrder(new Order{
                Id = Guid.NewGuid(),
                ShoppingCart = request.ShoppingCart,
                IsPlaced = false
            });
            return Task.FromResult(Unit.Value);
        }
    }
}