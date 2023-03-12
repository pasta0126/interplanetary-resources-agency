using Ira.Models.Entities;
using Ira.Repositories.Context;
using Ira.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ira.Repositories
{
    public class ShipRepository : GenericRepository<Ship>, IShipRepository
    {
        private readonly ILogger<ShipRepository> _logger;
        private readonly IraContext _context;
        public ShipRepository(
            ILogger<GenericRepository<Ship>> logger,
            IraContext context) : base(logger, context)
        {
            _context = context;
        }

        public new List<Ship> GetAll()
        {
            return _context.Ship
                .Include(x => x.Crew)
                .ThenInclude(x => x.Employees)
                .ToList();
        }
    }
}
