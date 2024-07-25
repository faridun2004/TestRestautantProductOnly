using TestRestautantProductOnly.Model.Shipments;

namespace TestRestautantProductOnly.Repository
{
    public interface IShipmentRepository
    {
        Task<IEnumerable<Shipment>> GetAllShipmentsAsync();
        Task<Shipment?> GetShipmentByIdAsync(Guid shipmentId);
        Task AddShipmentAsync(Shipment shipment);
        Task UpdateShipmentAsync(Shipment shipment);
        Task DeleteShipmentAsync(Guid shipmentId);
        Task SaveChangesAsync();
    }
}
