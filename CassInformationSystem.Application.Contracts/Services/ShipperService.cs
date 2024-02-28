using CassInformationSystem.Application.Contracts;
using CassInformationSystem.EnitiyFramework.Entities;
using CassInformationSystem.EnitiyFramework.Repository;

namespace CassInformationSystem.Application.Services
{
    public class ShipperService : IShipperService
    {
        private readonly IRepository<Shipper> _repository;
        private readonly IRepository<ShipperShipmentDetails> _shipmentReposiotry;

        public ShipperService(IRepository<Shipper> repository, IRepository<ShipperShipmentDetails> shipmentReposiotry)
        {
            _repository = repository;
            _shipmentReposiotry = shipmentReposiotry;
        }

        public async Task<IEnumerable<ShipperShipmentDetails>?> GetShipperShipmentDetails(int shipperId)
        {
            var shipementDetailsList= await _shipmentReposiotry.ExecuteStoredProc(shipperId);
            return shipementDetailsList.OrderBy(o=>o.Shipper_Name);
        }

        public async Task<IEnumerable<Shipper>> GetShippers()
        {
            var shippersList = await _repository.GetAll();
            return shippersList.OrderBy(o=>o.ShipperName);
        }
    }
}
