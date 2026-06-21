using MediatR;
using Product.MicroService.Domain.Helpers;
using System.Diagnostics;

namespace Product.MicroService.Domain.Pipelines;

internal class MonitoringPipelineBehaviour<TRequest, TResponse>()
: IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public static readonly ActivitySource ActivitySource = new ActivitySource(Constants.ActivitySourceName);
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        using var activity = ActivitySource.StartActivity(typeof(TRequest).Name, ActivityKind.Internal);

        return await next.Invoke();
    }
}