using System.Diagnostics.Metrics;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Metrics;

namespace monitor;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection serviceCollection)
    {
        var ourMeter = new Meter("Kpi");
        serviceCollection.AddSingleton(ourMeter);
        serviceCollection.AddHostedService<KpiService>();
        serviceCollection.AddOpenTelemetry().WithMetrics(meterProviderBuilder =>
        {
            meterProviderBuilder.AddMeter("MyMeter");
            meterProviderBuilder.AddMeter("Kpi");
            meterProviderBuilder.AddOtlpExporter((_, metricReaderOptions) =>
            {
                metricReaderOptions.PeriodicExportingMetricReaderOptions.ExportIntervalMilliseconds = 2000;
            });
        });
        
        //Environment.SetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT", "http://collector:4317");

        return serviceCollection;
    }
}