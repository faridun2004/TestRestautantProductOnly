using MediatR;
using TestRestautantProductOnly.Model.Shipments;

namespace TestRestautantProductOnly.CommandsQueries.Queries.GetAll
{
    public record GetShipmentsQuery : IRequest<IEnumerable<Shipment>>;
}
