using Ira.Api.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Ira.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class FakeController : ControllerBase
    {
        private readonly ILogger<FakeController> _logger;

        public FakeController(
            ILogger<FakeController> logger)
        {
            _logger = logger;
        }

        [HttpPost("ship/create")]
        public ActionResult CreateShip(int quantity)
        {
            if (quantity <= 0)
            {
                return BadRequest("The parameter must be greater than 0");
            }

            return Ok();
        }

    }
}
