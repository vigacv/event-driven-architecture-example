using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderingService.Models;

namespace OrderingService.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new List<Order>();
        public Task AddOrder(Order order)
        {
            _orders.Add(order);
            return Task.CompletedTask;
        }

        public Task<Order?> GetOrder(Guid orderId)
        {
            return Task.FromResult(_orders.FirstOrDefault(x => x.Id == orderId));
        }

        public Task<List<Order>> GetOrders()
        {
            return Task.FromResult(_orders);
        }
    }
}