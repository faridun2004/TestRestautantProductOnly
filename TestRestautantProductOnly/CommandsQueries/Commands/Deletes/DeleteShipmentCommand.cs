using MediatR;

namespace TestRestautantProductOnly.CommandsQueries.Commands.Deletes
{
    public record DeleteShipmentCommand(Guid ShipmentId) : IRequest<Unit>;
}
