using Ira.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ira.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class ShipController : ControllerBase
    {
        private readonly ILogger<ShipController> _logger;
        private readonly IShipService _service;

        public ShipController(
            ILogger<ShipController> logger,
            IShipService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public ActionResult CreateShip([FromQuery] int quantity)
        {
            if (quantity <= 0)
            {
                return BadRequest("The parameter must be greater than 0");
            }

            var ships = _service.CreateShip(quantity);

            return Ok(ships);
        }
    }
}
