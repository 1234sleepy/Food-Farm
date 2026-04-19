using Gateway.API.Dtos;
using Gateway.API.Extensions;
using Gateway.Domain.Services.JwtTokenService;
using Gateway.Domain.UseCases.AuthOperation.CreateAccount;
using Gateway.Domain.UseCases.AuthOperation.LogIn;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers;

[ApiController, Route("api/auth"),]
public class AuthController(IMediator mediator, IConfiguration configuration) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly IConfiguration _configuration = configuration;

    [HttpPost("create")]
    public async Task<ActionResult> CreateAccount([FromBody] CreateAccountCommand account,
    CancellationToken cancellationToken)
    {
        await _mediator.Send(account, cancellationToken);
        return Ok();
    }

    [HttpGet("check"), Authorize]
    public async Task<ActionResult> Check(CancellationToken cancellationToken)
    {
        var id = User.GetUserId();
        var userName = User.GetUserName();
        var roles = User.GetUserRoles();

        LoginResultDto res = new()
        {
            Id = id,
            UserName = userName,
            Roles = roles
        };

        return Ok(res);
    }


    [HttpPost("login")]
    public async Task<ActionResult> LogIn([FromBody] LogInCommand user,
    CancellationToken cancellationToken)
    {

        var model = await _mediator.Send(user, cancellationToken);
        HttpContext.Response.Cookies.Append("access_token", model.Token!,
            new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTimeOffset.UtcNow.AddDays(int.Parse(_configuration["Auth:TokenExpirationDays"]!)),
                SameSite = SameSiteMode.None,
            });

        LoginResultDto res = new()
        {
            Id = model.Id,
            UserName = model.UserName!,
            Roles = model.Roles!
        };

        return Ok(res);
    }
}
