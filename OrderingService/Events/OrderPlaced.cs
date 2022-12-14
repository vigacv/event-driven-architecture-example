using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace OrderingService.Events
{
    public class OrderPlaced: INotification
    {
        public string Type => nameof(OrderPlaced);
        public Guid OrderId { get; set; }
    }
}