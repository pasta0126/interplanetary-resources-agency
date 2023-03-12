using Ira.Models.Entities;
using Ira.Repositories.Context;
using Ira.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Ira.Repositories
{
    public class ShipRepository : GenericRepository<Ship>, IShipRepository
    {
        public ShipRepository(ILogger<GenericRepository<Ship>> logger, IraContext context) : base(logger, context)
        {
        }
    }
}
