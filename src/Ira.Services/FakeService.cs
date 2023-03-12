using FakerDotNet;
using Ira.Models.Entities;
using Ira.Models.Enums;
using Ira.Repositories;
using Ira.Repositories.Interfaces;
using Ira.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ira.Services
{
    public class FakeService : IFakeService
    {
        private readonly ILogger<FakeService> _logger;
        private readonly IShipRepository _repoShip;
        private readonly IMissionRepository _repoMission;

        public FakeService(
            ILogger<FakeService> logger,
            IShipRepository repoShip,
            IMissionRepository repoMission)
        {
            _logger = logger;
            _repoShip = repoShip;
            _repoMission = repoMission;
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
                    Name = Faker.Space.LaunchVehicle(),
                    Type = Faker.StarWars.Vehicle(),
                });
            }

            _repoShip.InsertRange(result);

            return result;
        }

        public Crew CreateCrew()
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Description = Faker.Hipster.Sentence(),
                Name = Faker.Team.Mascot(),
                Employees = CreateEmployees(Faker.Number.Between(3, 10)),
            };
        }

        public List<Employee> CreateEmployees(double quantity)
        {
            var result = new List<Employee>();

            for (int i = 0; i < quantity; i++)
            {
                result.Add(new Employee()
                {
                    Id = Guid.NewGuid(),
                    AidCard = Faker.Company.SpanishOrganisationNumber(),
                    CompleteName = Faker.Name.Name(),
                    Description = Faker.ChuckNorris.Fact(),
                    Email = Faker.Internet.Email(),
                    Position = GetPosition(i).ToString(),
                });
            }

            return result;
        }

        public EmployeePosition GetPosition(int position)
        {
            if (position <= 1)
            {
                return (EmployeePosition)position;
            }

            return Utilities.RandomFromEnum<EmployeePosition>();
        }

        public Mission CreateMission()
        {
            var ship = GetShip();
            var route = CreateRoute();

            var result = new Mission()
            {
                Id = Guid.NewGuid(),
                Name = Faker.Company.Industry(),
                Description = Faker.Company.CatchPhrase(),
                Labels = GetLabels(),
                Ship = ship,
                Route = route,
                Notifications = CreateNotifications(ship.Crew, ship, route),
            };

            _repoMission.Insert(result);

            return result;
        }

        private List<Notification> CreateNotifications(Crew crew, Ship ship, Route route)
        {
            var result = new List<Notification>();

            crew.Employees.ForEach((employee) =>
            {
                var id = Guid.NewGuid();

                result.Add(new()
                {
                    Id = id,
                    Email = employee.Email,
                    Subject = CreateSubject(id, ship, route),
                    Message = CreateMessage(route),
                    IsSentOk = false,
                    SentDate = null,
                });
            });

            return result;
        }

        private string CreateSubject(Guid id, Ship ship, Route route)
        {
            return $"IRA Mission {id} for {ship.Name} from {route.Origin.Planet} to {route.Destination.Planet}";
        }

        private string CreateMessage(Route route)
        {
            return $"\n" +
                $"Id: {route.Id}\n" +
                $"Name: {route.Name}\n" +
                $"Description: {route.Description}\n" +
                $"Cargo: {route.CargoDescription}\n" +
                $"Value: {route.CargoValue}\n" +
                $"----------------------------------\n" +
                $"Origin:\n" +
                $"{JsonConvert.SerializeObject(route.Origin)}\n" +
                $"----------------------------------\n" +
                $"Destination:\n" +
                $"{JsonConvert.SerializeObject(route.Description)}\n" +
                $"";
        }

        public List<Label> GetLabels()
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

        public Ship GetShip()
        {
            var ships = _repoShip.GetAll();
            var i = Faker.Number.Between(0, ships.Count);

            return ships[Convert.ToInt32(i)];
        }

        public Route CreateRoute()
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

        public Location CreateLocation()
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
