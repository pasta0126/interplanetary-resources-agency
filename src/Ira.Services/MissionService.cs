using Ira.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Ira.Services
{
    public class MissionService: IMissionService
    {
        private readonly ILogger<MissionService> _logger;

        public MissionService(
            ILogger<MissionService> logger)
        {
            _logger = logger;
        }

    }
}