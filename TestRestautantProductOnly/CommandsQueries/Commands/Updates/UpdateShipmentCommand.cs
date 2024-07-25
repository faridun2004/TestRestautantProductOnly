using MediatR;
using TestRestautantProductOnly.Model.Shipments;

namespace TestRestautantProductOnly.CommandsQueries.Commands.Updates
{
    public record UpdateShipmentCommand
    (   
        Guid ShipmentId,
        Status Status,
        DateTime UpdatedStatusDateTime
    ) : IRequest<Unit>;
}
