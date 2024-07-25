using MediatR;
using TestRestautantProductOnly.Repository;

namespace TestRestautantProductOnly.CommandsQueries.Commands.Deletes
{
    public class DeleteShipmentCommandHandler : IRequestHandler<DeleteShipmentCommand, Unit>
    {
        private readonly IShipmentRepository _shipmentRepository;

        public DeleteShipmentCommandHandler(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        public async Task<Unit> Handle(DeleteShipmentCommand request, CancellationToken cancellationToken)
        {
            var shipment = await _shipmentRepository.GetShipmentByIdAsync(request.ShipmentId);
            if (shipment == null)
            {
                throw new Exception("Shipment not found");
            }

            await _shipmentRepository.DeleteShipmentAsync(request.ShipmentId);
            await _shipmentRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
