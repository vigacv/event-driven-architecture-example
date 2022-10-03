using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Options;
using ShippingService.Interfaces;
using ShippingService.Models;

namespace ShippingService.Services
{
    public class ServiceBusConsumer: IServiceBusConsumer
    {
        private readonly IProcessData _processData;
        private readonly ServiceBusClient _client;
        private readonly ServiceBusSettings _serviceBusSettings;
        private readonly ILogger _logger;
        private List<ServiceBusProcessor> _processors = new List<ServiceBusProcessor>();

        public ServiceBusConsumer(IProcessData processData,
            IOptions<ServiceBusSettings> serviceBusSettings,
            ILogger<ServiceBusConsumer> logger)
        {
            _processData = processData;
            _serviceBusSettings = serviceBusSettings.Value;
            _logger = logger;

            var connectionString = _serviceBusSettings.ConnectionString;
            _client = new ServiceBusClient(connectionString);
        }

        public async Task RegisterOnMessageHandlerAndReceiveMessages()
        {
            ServiceBusProcessorOptions _serviceBusProcessorOptions = new ServiceBusProcessorOptions
            {
                MaxConcurrentCalls = 1,
                AutoCompleteMessages = false,
            };

            foreach (var consumer in _serviceBusSettings.Consumers)
            {
                var processor = _client.CreateProcessor(consumer.Topic, consumer.Subscription, _serviceBusProcessorOptions);
                processor.ProcessMessageAsync += ProcessMessagesAsync;
                processor.ProcessErrorAsync += ProcessErrorAsync;
                await processor.StartProcessingAsync().ConfigureAwait(false);
                _processors.Add(processor);
            }
        }

        private Task ProcessErrorAsync(ProcessErrorEventArgs arg)
        {
            _logger.LogError(arg.Exception, "Message handler encountered an exception");
            _logger.LogDebug($"- ErrorSource: {arg.ErrorSource}");
            _logger.LogDebug($"- Entity Path: {arg.EntityPath}");
            _logger.LogDebug($"- FullyQualifiedNamespace: {arg.FullyQualifiedNamespace}");

            return Task.CompletedTask;
        }

        private async Task ProcessMessagesAsync(ProcessMessageEventArgs args)
        {
            var myPayload = args.Message.Body.ToObjectFromJson<OrderEvent>();
            _logger.LogInformation($"Received message with body: {myPayload.Type} {myPayload.OrderId}");
            await _processData.Process(myPayload).ConfigureAwait(false);
            await args.CompleteMessageAsync(args.Message).ConfigureAwait(false);
        }

        public async ValueTask DisposeAsync()
        {
            if (_processors != null && _processors.Any())
            {
                foreach (var processor in _processors)
                {
                    await processor.DisposeAsync().ConfigureAwait(false);
                }
            }

            if (_client != null)
            {
                await _client.DisposeAsync().ConfigureAwait(false);
            }
        }

        public async Task CloseQueueAsync()
        {
            if (_processors != null && _processors.Any())
            {
                foreach (var processor in _processors)
                {
                    await processor.StopProcessingAsync().ConfigureAwait(false);
                }
            }
        }
    }
}