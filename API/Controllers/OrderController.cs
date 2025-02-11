using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController, Route("api/order")]
public class OrderController : ControllerBase
{
    [HttpGet]
    public ActionResult Get()
    {
        return Ok("Order");
    }
}
