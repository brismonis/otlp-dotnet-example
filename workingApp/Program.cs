using System.Diagnostics.Metrics;
using workingMonitor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices();

var meter = new Meter("MyWorkingMeter");
var counter = meter.CreateCounter<int>("MyWorkingCounter");

var app = builder.Build();
app.MapGet("/", () =>
{
    counter.Add(10);
    return "Hello World!";
});

app.Run();