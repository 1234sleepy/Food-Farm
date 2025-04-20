using MediatR;

namespace Domain.UseCases.AccountOperations.Command.CreateAccount;

public class CreateAccountCommandHandler(ICreateAccountStorage createAccountStorage) : IRequestHandler<CreateAccountCommand>
{
    private readonly ICreateAccountStorage _createAccountStorage = createAccountStorage;
    public async Task Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        await _createAccountStorage.CreateAccount(request.UserName, request.Password, request.Email, request.Role, cancellationToken);
    }
}

