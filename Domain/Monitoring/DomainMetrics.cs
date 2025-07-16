using Microsoft.Extensions.Configuration;
using System.Collections.Concurrent;
using System.Diagnostics.Metrics;

namespace Domain.Monitoring;

public class DomainMetrics(IMeterFactory meterFactory, IConfiguration configuration)
{
    private readonly Meter _meter = meterFactory.Create(configuration["Monitoring:MeterName"]!);
    private readonly ConcurrentDictionary<string, Counter<int>> _counters = new();

    public void Increment(string counterName, int value)
    {
        _counters.GetOrAdd(counterName, _ => _meter.CreateCounter<int>(counterName)).Add(value);
    }
}
