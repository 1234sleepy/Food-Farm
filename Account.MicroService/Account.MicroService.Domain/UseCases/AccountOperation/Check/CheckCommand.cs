using MediatR;

namespace Account.MicroService.Domain.UseCases.AccountOperation.Check;

public record class CheckCommand(Guid UserId) : IRequest<string> { }



