using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ShippingService.Commands;
using ShippingService.Interfaces;
using ShippingService.Models;

namespace ShippingService.Services
{
    public class ProcessData : IProcessData
    {
        private IConfiguration _configuration;
        private ILogger<ProcessData> _logger;
        private readonly IMediator _mediator;

        public ProcessData(IConfiguration configuration, ILogger<ProcessData> logger, IMediator mediator)
        {
            _configuration = configuration;
            _logger = logger;
            _mediator = mediator;
        }
        public async Task Process(OrderEvent orderEvent)
        {
            _logger.Log(LogLevel.Information, $"Processing order {orderEvent.OrderId}");
            switch (orderEvent.Type)
            {
                case "OrderPlaced":
                    await _mediator.Send(new OrderPlaced { OrderId = orderEvent.OrderId });
                    break;
                case "OrderBilled":
                    await _mediator.Send(new OrderBilled { OrderId = orderEvent.OrderId });
                    break;
                default:
                    _logger.Log(LogLevel.Warning, $"Unknown order event type {orderEvent.Type}");
                    break;
            }
            return;
        }
    }
}