using Ira.Models.Entities;

namespace Ira.Services.Interfaces
{
    public interface INotificationService
    {
        List<Notification> CreateNotifications(Guid missionId, Crew crew, Ship ship, Route route);
    }
}
