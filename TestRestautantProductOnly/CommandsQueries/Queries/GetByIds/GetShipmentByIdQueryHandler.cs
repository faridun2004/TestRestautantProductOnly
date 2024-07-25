using MediatR;
using TestRestautantProductOnly.Model.Shipments;
using TestRestautantProductOnly.Repository;

namespace TestRestautantProductOnly.CommandsQueries.Queries.GetByIds
{
    public class GetShipmentByIdQueryHandler : IRequestHandler<GetShipmentByIdQuery, Shipment>
    {
        private readonly IShipmentRepository _shipmentRepository;

        public GetShipmentByIdQueryHandler(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        public async Task<Shipment> Handle(GetShipmentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _shipmentRepository.GetShipmentByIdAsync(request.ShipmentId);
        }
    }
}
