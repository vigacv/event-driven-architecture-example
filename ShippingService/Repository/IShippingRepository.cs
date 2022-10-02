using ShippingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Repository
{
    public interface IShippingRepository
    {
        Task StoreShippingDetails(ShippingDetails shippingDetails);
        Task<ShippingDetails?> GetShippingDetails(Guid orderId);
        Task<List<ShippingDetails>> GetAllShippingDetails();
    }
}