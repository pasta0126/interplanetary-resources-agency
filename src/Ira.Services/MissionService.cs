using FakerDotNet;
using Ira.Models.Entities;
using Ira.Repositories.Interfaces;
using Ira.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Ira.Services
{
    public class MissionService : IMissionService
    {
        private readonly ILogger<MissionService> _logger;
        private readonly IMissionRepository _repoMission;
        private readonly IShipService _shipService;
        private readonly INotificationService _notificationService;

        public MissionService(
            ILogger<MissionService> logger,
            IMissionRepository repoMission,
            IShipService shipService,
            INotificationService notificationService)
        {
            _logger = logger;
            _repoMission = repoMission;
            _shipService = shipService;
            _notificationService = notificationService;
        }

        public Mission CreateMission()
        {
            var ship = _shipService.GetShip();
            var route = CreateRoute();

            var result = new Mission()
            {
                Id = Guid.NewGuid(),
                Name = Faker.Company.Industry(),
                Description = Faker.Company.CatchPhrase(),
                Labels = GetLabels(),
                Ship = ship,
                Route = route,
                Notifications = _notificationService.CreateNotifications(ship.Crew, ship, route),
            };

            _repoMission.Insert(result);

            return result;
        }

        private List<Label> GetLabels()
        {
            var input = Faker.Hipster.Words().ToList();
            var result = new List<Label>();

            input.ForEach((label) =>
            {
                result.Add(new()
                {
                    Id = Guid.NewGuid(),
                    Name = label,
                });
            });

            return result;
        }


        private Route CreateRoute()
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Name = Faker.StarWars.CallSign(),
                Description = Faker.Hipster.Paragraph(),
                CargoDescription = Faker.Commerce.Material(),
                CargoValue = Faker.Number.Positive(),
                Origin = CreateLocation(),
                Destination = CreateLocation(),
            };
        }

        private Location CreateLocation()
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Cluster = Faker.Space.StarCluster(),
                Nebula = Faker.Space.Nebula(),
                Galaxy = Faker.Space.Galaxy(),
                Planet = Faker.Space.Planet(),
                Comments = Faker.RickAndMorty.Location(),
                A = Convert.ToDecimal(Faker.Compass.Azimuth()),
                CA = Convert.ToDecimal(Faker.Compass.Azimuth()),
                OA = Convert.ToDecimal(Faker.Compass.Azimuth()),
                HwA = Convert.ToDecimal(Faker.Compass.Azimuth()),
                QwA = Convert.ToDecimal(Faker.Compass.Azimuth()),
            };
        }
    }
}
