namespace ServiceBusSample.Api.Models
{
    /// <summary>
    /// Generic wrapper for events sent via Service Bus.
    /// </summary>
    /// <typeparam name="T">The payload type of the event.</typeparam>
    public class ServiceBusEvent<T>
    {
        /// <summary>
        /// Unique identifier for this event instance.
        /// </summary>
        public Guid EventId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Logical type of the event (e.g., "OrderCreated").
        /// </summary>
        public string EventType { get; set; } = typeof(T).Name;

        /// <summary>
        /// Version of the event schema.
        /// </summary>
        public string Version { get; set; } = "v1";

        /// <summary>
        /// Correlation ID for tracing across services.
        /// </summary>
        public string CorrelationId { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// UTC timestamp when the event was created.
        /// </summary>
        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// The actual payload of the event.
        /// </summary>
        public T Payload { get; set; }

        public ServiceBusEvent(T payload)
        {
            Payload = payload;
        }
    }
}
