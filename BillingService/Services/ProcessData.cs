using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingService.Interfaces;
using BillingService.Models;

namespace BillingService.Services
{
    public class ProcessData : IProcessData
    {
        private IConfiguration _configuration;
        private ILogger<ProcessData> _logger;
 
        public ProcessData(IConfiguration configuration, ILogger<ProcessData> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public Task Process(OrderEvent orderEvent)
        {
            _logger.Log(LogLevel.Information, $"Processing order {orderEvent.OrderId}");
            return Task.CompletedTask;
        }
    }
}