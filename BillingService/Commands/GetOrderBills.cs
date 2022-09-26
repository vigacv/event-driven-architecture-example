using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingService.Models;
using MediatR;

namespace BillingService.Commands
{
    public class GetOrderBills: IRequest<List<OrderBill>>
    {
    }
}