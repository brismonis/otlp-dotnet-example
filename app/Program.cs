using System.Diagnostics.Metrics;
using monitor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices();

var meter = new Meter("MyMeter");
var counter = meter.CreateCounter<int>("MyCounter");

var app = builder.Build();
app.MapGet("/", () =>
{
    counter.Add(10);
    return "Hello World!";
});

app.Run();