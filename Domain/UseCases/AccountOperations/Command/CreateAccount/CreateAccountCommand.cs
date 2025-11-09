using MediatR;

namespace Domain.UseCases.AccountOperations.Command.CreateAccount;

public record class CreateAccountCommand(string UserName, string Password, string Email, string Role) : IRequest
{
}
