using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using OrderingService.Models;
using OrderingService.Repository;

namespace OrderingService.Commands
{
    public class GetOrdersHandler: IRequestHandler<GetOrders, List<Order>>
    {
        private readonly IOrderRepository _orderRepository;
        public GetOrdersHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public Task<List<Order>> Handle(GetOrders request, CancellationToken cancellationToken)
        {
            return _orderRepository.GetOrders();
        }
    }
}