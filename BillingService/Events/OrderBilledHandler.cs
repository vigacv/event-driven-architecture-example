using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using BillingService.Models;
using MediatR;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BillingService.Events
{
    public class OrderBilledHandler : INotificationHandler<OrderBilled>
    {
        private readonly ServiceBusSettings _serviceBusSettings;

        public OrderBilledHandler(IOptions<ServiceBusSettings> serviceBusSettings)
        {
            _serviceBusSettings = serviceBusSettings.Value;
        }
        public async Task Handle(OrderBilled notification, CancellationToken cancellationToken)
        {
            var client = new ServiceBusClient(_serviceBusSettings.ConnectionString);
            var sender = client.CreateSender(_serviceBusSettings.PublishTopic);

            using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

            string messageBody = JsonConvert.SerializeObject(notification);

            if (!messageBatch.TryAddMessage(new ServiceBusMessage(messageBody)))
            {
                // if it is too large for the batch
                throw new Exception($"The message is too large to fit in the batch.");
            }

            try
            {
                // Use the producer client to send the batch of messages to the Service Bus topic
                await sender.SendMessagesAsync(messageBatch);
            }
            finally
            {
                // Calling DisposeAsync on client types is required to ensure that network
                // resources and other unmanaged objects are properly cleaned up.
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }
        }
    }
}