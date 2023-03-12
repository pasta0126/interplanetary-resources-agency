using Ira.Models.Entities;

namespace Ira.Services.Interfaces
{
    public interface INotificationService
    {
        List<Notification> CreateNotifications(Crew crew, Ship ship, Route route);
    }
}
