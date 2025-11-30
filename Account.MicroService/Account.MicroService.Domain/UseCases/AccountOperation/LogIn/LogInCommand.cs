using Account.MicroService.Domain.Models;
using MediatR;

namespace Account.MicroService.Domain.UseCases.AccountOperation.LogIn;

public record class LogInCommand(string username, string password) : IRequest<UserModel>
{
}