using Azure.Messaging.ServiceBus;
using ServiceBusSample.Api.Models;
using ServiceBusSample.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
var serviceBusConnectionString = builder.Configuration["AzureServiceBus:ConnectionString"];
builder.Services.AddSingleton(_ => new ServiceBusClient(serviceBusConnectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/events/orders", async (OrderCreatedEvent orderCreated, ServiceBusClient client) =>
{
    var evt = new ServiceBusEvent<OrderCreatedEvent>(orderCreated)
    {
        EventType = "OrderCreated",
        Version = "v1",
        CorrelationId = "trace-789",
        Payload = orderCreated
    };

    var sender = client.CreateSender("orders-queue");
    // Use JSON and set a clear message type
    var message = new ServiceBusMessage(System.Text.Json.JsonSerializer.Serialize(evt))
    {
        ContentType = "application/json"
    };
    message.ApplicationProperties["type"] = "OrderCreated";
    await sender.SendMessageAsync(message);
    return Results.Accepted();
});

app.Run();
