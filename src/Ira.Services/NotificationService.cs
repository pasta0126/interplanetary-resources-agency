using Ira.Models.Entities;
using Ira.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ira.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(
            ILogger<NotificationService> logger)
        {
            _logger = logger;
        }

        public List<Notification> CreateNotifications(Crew crew, Ship ship, Route route)
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
            return $"IRA Mission {id.ToString().Split('-')[0]} from {route.Origin.Planet} to {route.Destination.Planet}";
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
    }
}
