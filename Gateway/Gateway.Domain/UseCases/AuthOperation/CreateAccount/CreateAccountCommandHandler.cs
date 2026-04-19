using FoodFarm.Account.MicroService.API.Grpc;
using MediatR;

namespace Gateway.Domain.UseCases.AuthOperation.CreateAccount;

public class CreateAccountCommandHandler(AccountEngine.AccountEngineClient client) : IRequestHandler<CreateAccountCommand>
{
    private readonly AccountEngine.AccountEngineClient _client = client;
    public async Task Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        await _client.CreateAsync(new AccountCreateRequest
        {
            Username = request.UserName,
            Email = request.Email,
            Password = request.Password,
        },
        cancellationToken: cancellationToken
        );
    }
}
