using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderingService.Models;

namespace OrderingService.Repository
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrders();
        Task AddOrder(Order order);
        Task<Order?> GetOrder(Guid orderId);
    }
}