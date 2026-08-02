using Cart.MicroService.Domain.UseCases.ResetCart;
using MediatR;
using System.Threading;

namespace Cart.MicroService.Domain.UseCases.ResetCartWolverine;

public record ResetCartCommand(Guid UserId);

public class ResetCartHandler(IResetCartStorage storage)
{
    private IResetCartStorage _storage = storage;
    public async Task Handle(ResetCartCommand command, CancellationToken ct)
    {
        await _storage.ResetCart(command.UserId, ct);
    }
}