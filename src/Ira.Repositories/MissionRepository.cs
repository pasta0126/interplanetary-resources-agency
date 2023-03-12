using Ira.Models.Entities;
using Ira.Repositories.Context;
using Ira.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Ira.Repositories
{
    public class MissionRepository : GenericRepository<Mission>, IMissionRepository
    {
        public MissionRepository(ILogger<GenericRepository<Mission>> logger, IraContext context) : base(logger, context)
        {
        }
    }
}
