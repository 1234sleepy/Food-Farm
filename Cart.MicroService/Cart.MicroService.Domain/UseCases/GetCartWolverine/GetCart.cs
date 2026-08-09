using Cart.MicroService.Domain.UseCases.ResetCartWolverine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.MicroService.Domain.UseCases.GetCartWolverine;

public record GetCartCommand(Guid UserId);

public class GetCartHandler(IGetCartStorage storage)
{
    private readonly IGetCartStorage _storage = storage;
    public async Task Handle(ResetCartCommand command, CancellationToken ct)
    {
        await _storage.GetCart(command.UserId, ct);
    }
}