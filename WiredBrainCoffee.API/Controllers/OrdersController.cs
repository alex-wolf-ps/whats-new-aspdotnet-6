using Microsoft.AspNetCore.Mvc;

namespace WiredBrainCoffee.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ILogger<OrdersController> logger)
        {
            _logger = logger;
        }

        [HttpGet("history")]
        public IActionResult Get()
        {
            // Do this in minimal API?

            return Ok();
        }
    }
}
