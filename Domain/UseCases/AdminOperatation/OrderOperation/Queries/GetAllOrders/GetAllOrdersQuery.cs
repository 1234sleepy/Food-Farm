using Domain.Models;
using Domain.UseCases.AdminOperatation.OrderOperation.Base;
using Domain.UseCases.Base;
using MediatR;

namespace Domain.UseCases.AdminOperatation.OrderOperation.Queries.GetAllOrders
{
    public record class GetAllOrdersQuery(string? Sort): PaginationQuery, IRequest<PaginationList<OrderModel>>
    {
    }
}
