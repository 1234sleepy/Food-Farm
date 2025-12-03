using MediatR;

namespace Cart.MicroService.Domain.UseCases.ResetCart;

public record class ResetCartCommand(Guid UserId) : IRequest
{
}
