using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingService.Models;

namespace BillingService.Interfaces
{
    public interface IProcessData
    {
        Task Process(OrderEvent orderEvent);
    }
}