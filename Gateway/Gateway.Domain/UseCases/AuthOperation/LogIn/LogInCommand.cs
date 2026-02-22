using Gateway.Domain.Models;
using MediatR;

namespace Gateway.Domain.UseCases.AuthOperation.LogIn;

public record class LogInCommand(string username, string password) : IRequest<UserModel>
{
}