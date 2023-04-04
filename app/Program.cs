using System.Diagnostics.Metrics;
using OpenTelemetry.Metrics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenTelemetry().WithMetrics(builder =>
{
    builder.AddMeter("MyMeter");
    builder.AddOtlpExporter((exporterOptions, metricReaderOptions) =>
    {
        metricReaderOptions.PeriodicExportingMetricReaderOptions.ExportIntervalMilliseconds = 2000;
    });
});

var app = builder.Build();


var meter = new Meter("MyMeter");
var counter = meter.CreateCounter<int>("MyCounter");

app.MapGet("/", () =>
{
    counter.Add(1);
    return "Hello World!";
});

app.Run();
