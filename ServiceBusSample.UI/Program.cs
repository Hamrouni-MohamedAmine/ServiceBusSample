using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ServiceBusSample.UI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

// If you want a base address (e.g., your backend API):
builder.Services.AddHttpClient("Api", client =>
{
    client.BaseAddress = new Uri("https://localhost:5001"); // your API base URL
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
