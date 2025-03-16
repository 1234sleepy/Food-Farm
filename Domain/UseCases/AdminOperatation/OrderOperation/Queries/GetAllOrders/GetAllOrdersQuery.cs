using Domain.Models;
using Domain.UseCases.AdminOperatation.AdminOrderOperation.Base;
using Domain.UseCases.Base;
using MediatR;

namespace Domain.UseCases.AdminOperatation.AdminOrderOperation.Queries.GetAllOrders
{
    public record class GetAllOrdersQuery(string? Sort): PaginationQuery, IRequest<PaginationList<OrderModel>>
    {
    }
}
