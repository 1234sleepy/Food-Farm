using MediatR;

namespace Cart.MicroService.Domain.UseCases.ResetCart;

public class ResetCartCommandHandler(IResetCartCommand storage) : IRequestHandler<ResetCartCommand>
{
    private IResetCartCommand _storage = storage;
    public async Task Handle(ResetCartCommand request, CancellationToken cancellationToken)
    {
        await _storage.ResetCartCommand(request.UserId, cancellationToken);
    }
}
