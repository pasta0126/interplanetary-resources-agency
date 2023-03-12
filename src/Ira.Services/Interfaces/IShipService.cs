using Ira.Models.Entities;

namespace Ira.Services.Interfaces
{
    public interface IShipService
    {
        Ship GetShip();
        List<Ship> GetShipList();
        List<Ship> CreateShip(int quantity);
    }
}
