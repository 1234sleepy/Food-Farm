using API.Dtos;
using API.Extensions;
using Domain.UseCases.AccountOperations.Command.Check;
using Domain.UseCases.AccountOperations.Command.LogIn;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Storage.Entities;

namespace API.Controllers;

[ApiController, Route("api/account")]

public class AccountController(IMediator mediator, IConfiguration configuration) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly IConfiguration _configuration = configuration;

    [HttpPost("login")]
    public async Task<ActionResult> LogIn([FromBody] LogInCommand user,
    CancellationToken cancellationToken)
    {
        
        var model = await _mediator.Send(user, cancellationToken);
        HttpContext.Response.Cookies.Append("access_token", model.Token,
            new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTimeOffset.UtcNow.AddDays(int.Parse(_configuration["Auth:TokenExpirationDays"]!)),
                SameSite = SameSiteMode.None,
            });

        LoginResultDto res = new()
        { 
            UserName = user.username
        };

        return Ok(res);
    }

    [HttpGet("check"), Authorize]
    public async Task<ActionResult> Check(CancellationToken cancellationToken)
    {
        var model = new CheckCommand(User.GetUserId());
        var ress = await _mediator.Send(model);

        LoginResultDto res = new()
        {
            UserName = ress
        };

        return Ok(res);
    }

    [HttpDelete("logout"), Authorize]
    public ActionResult LogOut(CancellationToken cancellationToken)
    {
        HttpContext.Response.Cookies.Delete("access_token");
        return Ok();
    }
}
