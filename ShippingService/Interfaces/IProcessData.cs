using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShippingService.Models;

namespace ShippingService.Interfaces
{
    public interface IProcessData
    {
        Task Process(OrderEvent orderEvent);
    }
}