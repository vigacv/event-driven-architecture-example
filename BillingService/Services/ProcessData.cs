using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingService.Commands;
using BillingService.Interfaces;
using BillingService.Models;
using MediatR;

namespace BillingService.Services
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
            await _mediator.Send(new BillOrder { OrderId = orderEvent.OrderId });
            return;
        }
    }
}