using ShippingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Repository
{
    public class ShippingRepository : IShippingRepository
    {
        private readonly List<ShippingDetails> _shippingDetails = new List<ShippingDetails>();
        public Task<List<ShippingDetails>> GetAllShippingDetails()
        {
            return Task.FromResult(_shippingDetails);
        }

        public Task<ShippingDetails?> GetShippingDetails(Guid orderId)
        {
            return Task.FromResult(_shippingDetails.FirstOrDefault(x => x.OrderId == orderId));
        }

        public Task StoreShippingDetails(ShippingDetails shippingDetails)
        {
            _shippingDetails.Add(shippingDetails);
            return Task.CompletedTask;
        }
    }
}