using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace BillingService.Commands
{
    public class BillOrder: IRequest<Unit>
    {
        public Guid OrderId { get; set; }
    }
}