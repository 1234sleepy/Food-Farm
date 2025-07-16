using Domain.Monitoring;
using FluentValidation;
using MediatR;

namespace Domain.Pipelines;

public class MonitorPipelineBehavior<TRequest, TResponse>(DomainMetrics metrics)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly DomainMetrics _metrics = metrics;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Monitoring request: {request.GetType().Name}");
        if (request is not IMonitoringRequest monitoringRequest)
        {
            return await next.Invoke();
        }

        var res = await next.Invoke();
        monitoringRequest.MonitorSuccess(_metrics);
        return res;
    }
}

