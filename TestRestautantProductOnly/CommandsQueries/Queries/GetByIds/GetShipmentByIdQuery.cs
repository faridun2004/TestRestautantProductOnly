using MediatR;
using TestRestautantProductOnly.Model.Shipments;

namespace TestRestautantProductOnly.CommandsQueries.Queries.GetByIds
{
    public record GetShipmentByIdQuery(Guid ShipmentId) : IRequest<Shipment>;
}
