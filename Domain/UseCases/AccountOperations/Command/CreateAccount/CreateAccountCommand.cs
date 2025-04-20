using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Domain.UseCases.AccountOperations.Command.CreateAccount;

public record class CreateAccountCommand(string UserName, string Password, string Email, string Role) : IRequest
{
}
