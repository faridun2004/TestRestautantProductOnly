using MediatR;
using TestRestautantProductOnly.Model.Shipments;

namespace TestRestautantProductOnly.CommandsQueries.Commands.Creates
{
    public record CreateShipmentCommand
    (
        Guid OrderId, 
        Guid CustomerId, 
        ShippingAddress ShippingAddress, 
        List<ShipmentItem> Items
    ):  IRequest<Guid>;
}
