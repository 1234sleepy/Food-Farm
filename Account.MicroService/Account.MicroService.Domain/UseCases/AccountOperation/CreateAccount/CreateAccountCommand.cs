using MediatR;

namespace Account.MicroService.Domain.UseCases.AccountOperation.CreateAccount;

public record class CreateAccountCommand(string UserName, string Password, string Email, string Role) : IRequest
{
}
