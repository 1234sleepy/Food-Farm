using Account.MicroService.Domain.UseCases.AccountOperation.CreateAccount;
using Account.MicroService.Domain.UseCases.AccountOperation.LogIn;
using FoodFarm.Account.MicroService.API.Grpc;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;

namespace Account.MicroService.API.Controlers;

public class AccountEngineGrpcService(IMediator mediator) : AccountEngine.AccountEngineBase
{
    private readonly IMediator _mediator = mediator;

    public override async Task<Empty> Create(AccountCreateRequest request, ServerCallContext context)
    {
        var command = new CreateAccountCommand(request.Username, request.Password, request.Email);
        await _mediator.Send(command);
        return new Empty();
    }

    public override async Task<LogInResponse> LogIn(LogInRequest request, ServerCallContext context)
    {
        try
        {
            var command = new LogInCommand(request.Username, request.Password);
            var model = await _mediator.Send(command);
            var response = new LogInResponse { Id = model.Id.ToString(), Email = model.Email, Username = model.Username };
            response.Roles.AddRange(model.Roles);

            return response;
        }
        catch (Exception ex)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, ex.Message));
        }
    }
}
