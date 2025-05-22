using Domain.Models;
using Domain.UseCases.AdminOperatation.OrderOperation.Base;
using Domain.UseCases.Base;
using MediatR;

namespace Domain.UseCases.OrderOperation.Queries.GetOrderByPhone;

public record class GetOrderByPhoneQuery(string Phone) : PaginationQuery, IRequest<PaginationList<OrderModel>>
{
}
