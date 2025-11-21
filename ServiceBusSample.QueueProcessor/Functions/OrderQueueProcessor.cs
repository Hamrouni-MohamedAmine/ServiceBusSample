using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using ServiceBusSample.Domain.Models;
using System.Text.Json;

namespace ServiceBusSample.QueueProcessor.Functions
{
    public class OrderQueueProcessor
    {
        private readonly ILogger<OrderQueueProcessor> _logger;

        public OrderQueueProcessor(ILogger<OrderQueueProcessor> logger)
        {
            _logger = logger;
        }

        [Function(nameof(OrderQueueProcessor))]
        public async Task Run(
            [ServiceBusTrigger("orders-queue", Connection = "ServiceBusConnection")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            var type = message.ApplicationProperties.TryGetValue("type", out var t) ? t?.ToString() : null;

            if (type != "OrderCreated")
            {
                _logger.LogWarning("Unknown message type: {Type}", type);
                return;
            }

            var evt = JsonSerializer.Deserialize<OrderCreatedEvent>(message.Body);
            _logger.LogInformation("Processing order {OrderId} amount {Amount} for customer {CustomerId}",
                evt?.OrderId, evt?.Amount, evt?.CustomerId);


            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }
    }
}
