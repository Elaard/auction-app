using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;
using Contracts;

namespace AuctionService
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

            CreateMap<Auction, AuctionDTO>()
               .IncludeMembers(x => x.Subject);

            CreateMap<UpdateAuctionDTO, Auction>();

            CreateMap<Subject, AuctionDTO>();

            CreateMap<CreateAuctionDTO, Auction>()
                .ForMember(d => d.Subject, o => o.MapFrom(s => s));

            CreateMap<CreateAuctionDTO, Subject>();
        }
    }
}
