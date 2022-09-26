using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingService.Models;

namespace BillingService.Repository
{
    public class BillingRepository: IBillingRepository
    {
        private List<OrderBill> _orderBills = new List<OrderBill>();

        public Task AddOrderBill(OrderBill orderBill)
        {
            _orderBills.Add(orderBill);
            return Task.CompletedTask;
        }

        public Task<List<OrderBill>> GetOrderBills()
        {
            return Task.FromResult(_orderBills);
        }

        public Task<OrderBill?> GetOrderBill(Guid orderId)
        {
            return Task.FromResult(_orderBills.FirstOrDefault(x => x.OrderId == orderId));
        }
    }
}