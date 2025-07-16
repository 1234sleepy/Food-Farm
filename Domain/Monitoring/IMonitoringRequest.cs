namespace Domain.Monitoring;

public interface IMonitoringRequest
{
    void MonitorSuccess(DomainMetrics metrics);
}
