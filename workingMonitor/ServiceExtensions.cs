using System.Diagnostics.Metrics;
using Microsoft.Extensions.DependencyInjection;
using monitor;
using OpenTelemetry.Metrics;

namespace workingMonitor;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection serviceCollection)
    {
        var ourMeter = new Meter("WorkingKpi");
        serviceCollection.AddSingleton(ourMeter);
        serviceCollection.AddHostedService<KpiService>();
        serviceCollection.AddOpenTelemetryMetrics(meterProviderBuilder =>
        {
            meterProviderBuilder.AddMeter("MyWorkingMeter");
            meterProviderBuilder.AddMeter("WorkingKpi");
            meterProviderBuilder.AddOtlpExporter((_, metricReaderOptions) =>
            {
                metricReaderOptions.PeriodicExportingMetricReaderOptions.ExportIntervalMilliseconds = 2000;
            });
        });

        return serviceCollection;
    }
}