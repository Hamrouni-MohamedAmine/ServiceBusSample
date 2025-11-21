namespace ServiceBusSample.Domain.Models
{
    public record OrderCreatedEvent(string OrderId, decimal Amount, string CustomerId, DateTime CreatedUtc);
}