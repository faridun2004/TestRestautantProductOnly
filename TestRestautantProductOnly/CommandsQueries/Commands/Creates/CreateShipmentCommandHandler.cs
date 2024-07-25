using AutoMapper;
using MediatR;
using TestRestautantProductOnly.Model.Shipments;
using TestRestautantProductOnly.Repository;

namespace TestRestautantProductOnly.CommandsQueries.Commands.Creates
{
    public class CreateShipmentCommandHandler : IRequestHandler<CreateShipmentCommand, Guid>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;

        public CreateShipmentCommandHandler(IShipmentRepository shipmentRepository, IMapper mapper)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateShipmentCommand request, CancellationToken cancellationToken)
        {
            // Преобразование команды в сущность
            var shipment = _mapper.Map<Shipment>(request);

            // Добавление сущности в репозиторий
            await _shipmentRepository.AddShipmentAsync(shipment);
            await _shipmentRepository.SaveChangesAsync();

            return shipment.ShipmentId;
        }
    }
}
