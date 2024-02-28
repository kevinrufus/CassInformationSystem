using CassInformationSystem.EnitiyFramework.Entities;

namespace CassInformationSystem.Application.Contracts
{
    public interface IShipperService
    {
        Task<IEnumerable<Shipper>> GetShippers();
        Task<IEnumerable<ShipperShipmentDetails>?> GetShipperShipmentDetails(int shipperId);
    }
}
