using MediatR;
using TestRestautantProductOnly.Model.Shipments;
using TestRestautantProductOnly.Repository;

namespace TestRestautantProductOnly.CommandsQueries.Queries.GetAll
{
    public class GetAllShipmentsQueryHandler : IRequestHandler<GetShipmentsQuery, IEnumerable<Shipment>>
    {
        private readonly IShipmentRepository _shipmentRepository;

        public GetAllShipmentsQueryHandler(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        public async Task<IEnumerable<Shipment>> Handle(GetShipmentsQuery request, CancellationToken cancellationToken)
        {
            return await _shipmentRepository.GetAllShipmentsAsync();
        }
    }
}
