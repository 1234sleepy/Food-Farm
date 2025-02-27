using Domain.UseCases.AdminOrderOperation.Queries.GetAllOrder;
using FluentValidation;

namespace Domain.UseCases.AdminOrderOperation.Queries.GetAllOrders
{
    public class GetAllOrdersCommandValidator : AbstractValidator<GetAllOrdersQuery>
    {
    }
}
