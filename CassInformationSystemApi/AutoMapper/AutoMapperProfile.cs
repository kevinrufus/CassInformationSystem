using AutoMapper;
using CassInformationSystem.Application.DTOs;
using CassInformationSystem.EnitiyFramework.Entities;
using CassInformationSystemApi.DTOs;

namespace CassInformationSystemApi.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Shipper, ShippersReturnableDto>();
            CreateMap<QuoteTransferableDto, Quotes>();
            CreateMap<ShipperShipmentDetails, ShipperShipmentDetailsReturnableDto>();
        }
    }
}
