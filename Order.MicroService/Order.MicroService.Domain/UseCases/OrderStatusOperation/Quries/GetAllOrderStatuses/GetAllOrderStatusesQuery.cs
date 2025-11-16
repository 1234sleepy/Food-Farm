using MediatR;
using Order.MicroService.Domain.UseCases.OrderStatusOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderStatusOperation.Quries.GetAllOrderStatuses;

public record class GetAllOrderStatusesQuery() : IRequest<List<OrderStatusModel>>
{
}