namespace CassInformationSystem.EnitiyFramework.Entities
{
    public class ShipperShipmentDetails
    {

        public int Shipment_Id { get; set; }
        public string? Shipper_Name{ get; set; }
        public string? Carrier_Name { get; set; }
        public string? Shipment_Description { get; set; }
        public decimal? Shipment_Weight { get; set; }
        public string? Shipment_Rate_Description { get; set; }
    }
}
