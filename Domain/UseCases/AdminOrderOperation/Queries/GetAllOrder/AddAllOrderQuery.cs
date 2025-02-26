using Domain.Models;
using Domain.UseCases.AdminOrderOperation.Base;
using Domain.UseCases.Base;
using MediatR;

namespace Domain.UseCases.AdminOrderOperation.Queries.GetAllOrder
{
    public record class AddAllOrderQuery(String? Sort): PaginationQuery, IRequest<PaginationList<OrderModel>>
    {
    }
}
