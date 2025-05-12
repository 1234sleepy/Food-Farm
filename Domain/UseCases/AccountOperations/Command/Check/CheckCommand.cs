using MediatR;

namespace Domain.UseCases.AccountOperations.Command.Check;

public record class CheckCommand(Guid UserId) : IRequest<string> { }


