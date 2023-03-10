using Ira.Api.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Ira.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class MissionController : ControllerBase
    {
        private readonly ILogger<MissionController> _logger;

        public MissionController(
            ILogger<MissionController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult PostMission(MissionPostRequest request)
        {
            return Ok();
        }
    }
}
