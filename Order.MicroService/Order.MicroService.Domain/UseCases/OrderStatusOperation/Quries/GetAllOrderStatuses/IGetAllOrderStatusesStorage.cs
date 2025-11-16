using Order.MicroService.Domain.UseCases.OrderStatusOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderStatusOperation.Quries.GetAllOrderStatuses;

public interface IGetAllOrderStatusesStorage
{
    Task<List<OrderStatusModel>> GetAllOrderStatuses(CancellationToken cancellationToken);
}