using Domain.Models;
using MediatR;

namespace Domain.UseCases.AccountOperations.Command.LogIn;

public record class LogInCommand(string username, string password) : IRequest<UserModel>
{
}
