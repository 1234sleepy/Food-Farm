using Domain.UseCases.AccountOperations.Command.LogIn;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController, Route("api/account")]

public class AccountController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("login")]
    public async Task<ActionResult> LogIn([FromBody] LogInCommand user,
    CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(user, cancellationToken));
    }
}
