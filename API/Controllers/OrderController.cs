using Microsoft.AspNetCore.Mvc;
using Storage.Entities;

namespace API.Controllers;

[ApiController, Route("api/order")]
public class OrderController : ControllerBase
{
    [HttpPost]
    public ActionResult AddOrder([FromQuery] Order query)
    {
        return Ok("Order");
    }
}
