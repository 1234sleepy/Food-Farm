using MediatR;

namespace Cart.MicroService.Domain.UseCases.ResetCart;

public class ResetCartCommandHandler(IResetCartStorage storage) : IRequestHandler<ResetCartCommand>
{
    private IResetCartStorage _storage = storage;
    public async Task Handle(ResetCartCommand request, CancellationToken cancellationToken)
    {
        await _storage.ResetCartCommand(request.UserId, cancellationToken);
    }
}
