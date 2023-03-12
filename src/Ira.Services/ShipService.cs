using FakerDotNet;
using Ira.Models.Entities;
using Ira.Repositories.Interfaces;
using Ira.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Ira.Services
{
    public class ShipService : IShipService
    {
        private readonly ILogger<ShipService> _logger;
        private readonly IShipRepository _repoShip;
        private readonly IEmployeeService _employeeService;

        public ShipService(
            ILogger<ShipService> logger,
            IShipRepository repoShip,
            IEmployeeService employeeService)
        {
            _logger = logger;
            _repoShip = repoShip;
            _employeeService = employeeService;
        }

        public Ship GetShip()
        {
            var ships = _repoShip.GetAll();
            var i = Faker.Number.Between(0, ships.Count);

            return ships[Convert.ToInt32(i)];
        }

        public List<Ship> GetShipList()
        {
            return _repoShip.GetAll();
        }

        public List<Ship> CreateShip(int quantity)
        {
            var result = new List<Ship>();

            for (int i = 0; i < quantity; i++)
            {
                result.Add(new Ship()
                {
                    Id = Guid.NewGuid(),
                    Description = Faker.Hipster.Sentence(),
                    Crew = CreateCrew(),
                    Type = Faker.Space.LaunchVehicle(),
                });
            }

            _repoShip.InsertRange(result);

            return result;
        }

        private Crew CreateCrew()
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Description = Faker.Hipster.Sentence(),
                Name = Faker.Team.Mascot(),
                Employees = _employeeService.CreateEmployees(Faker.Number.Between(3, 10)),
            };
        }
    }
}
