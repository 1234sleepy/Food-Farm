using Domain.UseCases.AdminOperatation.OrderOperation.Queries.GetAllOrders;
using Domain.UseCases.Comment.Command.AddComment;
using Domain.UseCases.Comment.Queries.GetCommentForProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController, Route("api/comment")]
public class CommentController(IMediator mediator, IConfiguration configuration) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly IConfiguration _configuration = configuration;

    [HttpPost]
    public async Task<ActionResult> AddComment([FromBody] AddCommentCommand model, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(model, cancellationToken));
    }

    [HttpGet]
    public async Task<ActionResult> GetCommentForProduct([FromQuery] GetCommentForProductQuery query, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(query, cancellationToken));
    }
}
