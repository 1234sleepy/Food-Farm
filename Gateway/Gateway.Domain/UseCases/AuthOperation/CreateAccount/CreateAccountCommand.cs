using MediatR;

namespace Gateway.Domain.UseCases.AuthOperation.CreateAccount;

public record class CreateAccountCommand(string UserName, string Password, string Email) : IRequest
{
}

