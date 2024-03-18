using AuctionService.DTOs;
using AutoMapper;
using Contracts;

namespace WebApi
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AuctionDTO, AuctionCreated>();
            CreateMap<AuctionDTO, AuctionUpdated>()
                .ForMember(x => x.Id, f => f.MapFrom(x => x.Id.ToString()))
                .ForMember(x => x.Make, f => f.MapFrom(x => x.Make))
                .ForMember(x => x.Model, f => f.MapFrom(x => x.Model))
                .ForMember(x => x.Year, f => f.MapFrom(x => x.Year))
                .ForMember(x => x.Color, f => f.MapFrom(x => x.Color))
                .ForMember(x => x.Mileage, f => f.MapFrom(x => x.Mileage));
        }
    }
}
