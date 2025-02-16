using Microsoft.AspNetCore.Mvc;
using Storage.Entities;

namespace API.Controllers;

[ApiController, Route("api/admin/order")]
public class AdminOrderController : ControllerBase
{
    [HttpPost]
    public ActionResult AddOrder([FromQuery] Order query)
    {
        return Ok("Order");
    }

    [HttpPut("{id:guid}")]
    public ActionResult UpdateOrder(Guid id, [FromQuery] Order query)
    {
        return Ok("Order");
    }

    [HttpDelete("{id:guid}")]
    public ActionResult DeleteOrder(Guid id)
    {
        return Ok("Order");
    }

    [HttpGet("{id:guid}")]
    public ActionResult GetOrder(Guid id)
    {
        return Ok("Order");
    }

    [HttpGet]
    public ActionResult GetAllOrder()
    {
        return Ok("Order");
    }

}
