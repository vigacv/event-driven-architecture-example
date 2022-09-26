using BillingService.Commands;
using BillingService.Interfaces;
using BillingService.Models;
using BillingService.Services;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(new System.Reflection.Assembly[] { typeof(BillOrderHandler).Assembly });

builder.Services.Configure<ServiceBusSettings>(builder.Configuration.GetSection("ServiceBus"));

builder.Services.AddSingleton<IServiceBusConsumer, ServiceBusConsumer>();
builder.Services.AddSingleton<IProcessData, ProcessData>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var host = app.Services.CreateScope();
var services = host.ServiceProvider;

var bus = services.GetRequiredService<IServiceBusConsumer>();
bus.RegisterOnMessageHandlerAndReceiveMessages().GetAwaiter().GetResult();

app.Run();
