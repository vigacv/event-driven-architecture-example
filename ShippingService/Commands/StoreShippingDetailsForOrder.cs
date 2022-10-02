using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ShippingService.Models;

namespace ShippingService.Commands
{
    public class StoreShippingDetailsForOrder: IRequest<Unit>
    {
        public ShippingDetails ShippingDetails { get; set; }
    }
}