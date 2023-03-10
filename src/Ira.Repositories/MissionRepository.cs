using Ira.Repositories.Context;
using Ira.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Ira.Repositories
{
    public class MissionRepository : IMissionRepository
    {
        private readonly ILogger<MissionRepository> _logger;
        private readonly IraContext _context;

        public MissionRepository(
            ILogger<MissionRepository> logger,
            IraContext context)
        {
            _logger = logger;
            _context = context;
        }

    }
}