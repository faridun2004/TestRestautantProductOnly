using AutoMapper;
using TestRestautantProductOnly.CommandsQueries.Commands.Creates;
using TestRestautantProductOnly.CommandsQueries.Commands.Deletes;
using TestRestautantProductOnly.CommandsQueries.Commands.Updates;
using TestRestautantProductOnly.CommandsQueries.Queries.GetAll;
using TestRestautantProductOnly.CommandsQueries.Queries.GetByIds;
using TestRestautantProductOnly.Model.Shipments;

namespace TestRestautantProductOnly.CommandsQueries.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
                CreateMap<Shipment, CreateShipmentCommand>()
                    .ReverseMap(); 
                CreateMap<Shipment, UpdateShipmentCommand>()
                    .ReverseMap(); 
                CreateMap<Shipment, DeleteShipmentCommand>()
                    .ForMember(dest => dest.ShipmentId, opt => opt.MapFrom(src => src.ShipmentId))
                    .ReverseMap(); 
                CreateMap<Shipment, GetShipmentByIdQuery>()
                    .ReverseMap();
                CreateMap<Shipment, GetShipmentsQuery>()
                    .ReverseMap(); 
            }
        }
    }

