using System.Diagnostics.Metrics;
using Microsoft.Extensions.Hosting;
using Timer = System.Timers.Timer;

namespace monitor;

public class KpiService : IHostedService, IDisposable
{
    private const int KpiInterval = 1000;
    private readonly Timer timer = new(KpiInterval);

    private int countA;
    private int countB;

    public KpiService(Meter meter)
    {
        meter.CreateObservableGauge("KpiMetrics.countA", () => countA);
        meter.CreateObservableGauge("KpiMetrics.countB", () => countB);
        timer.Elapsed += (_, _) => OnKpiUpdate();
    }

    private void OnKpiUpdate()
    {
        countB += 1;
        countA += 1;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        timer.Start();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        timer.Stop();
        return Task.CompletedTask;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            timer.Dispose();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}