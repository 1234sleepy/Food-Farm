using MediatR;

namespace Gateway.Domain.UseCases.AuthOperation.CreateAccount;

public class CreateAccountCommandHandler() : IRequestHandler<CreateAccountCommand>
{

    public async Task Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
       
    }
}
