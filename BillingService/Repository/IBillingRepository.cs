using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingService.Models;

namespace BillingService.Repository
{
    public interface IBillingRepository
    {
        Task<List<OrderBill>> GetOrderBills();
        Task AddOrderBill(OrderBill orderBill);
        Task<OrderBill?> GetOrderBill(Guid orderId);
    }
}