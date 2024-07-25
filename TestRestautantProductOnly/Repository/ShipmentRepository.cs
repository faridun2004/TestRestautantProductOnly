using Microsoft.EntityFrameworkCore;
using TestRestautantProductOnly.Infractruct;
using TestRestautantProductOnly.Model.Shipments;

namespace TestRestautantProductOnly.Repository
{
    public class ShipmentRepository: IShipmentRepository
    {
        private readonly RestaurantContext _context;

        public ShipmentRepository(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Shipment>> GetAllShipmentsAsync()
        {
            return await _context.Shipments
                .Include(s => s.Items)
                .Include(s => s.ShippingAddress)
                .ToListAsync();
        }

        public async Task<Shipment?> GetShipmentByIdAsync(Guid shipmentId)
        {
            return await _context.Shipments
                .Include(s => s.Items)
                .Include(s => s.ShippingAddress)
                .FirstOrDefaultAsync(s => s.ShipmentId == shipmentId);
        }

        public async Task AddShipmentAsync(Shipment shipment)
        {
            await _context.Shipments.AddAsync(shipment);
        }

        public async Task UpdateShipmentAsync(Shipment shipment)
        {
            _context.Shipments.Update(shipment);
        }

        public async Task DeleteShipmentAsync(Guid shipmentId)
        {
            var shipment = await GetShipmentByIdAsync(shipmentId);
            if (shipment != null)
            {
                _context.Shipments.Remove(shipment);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
