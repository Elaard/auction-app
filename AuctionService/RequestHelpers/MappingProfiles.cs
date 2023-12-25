using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;

namespace AuctionService.RequestHelpers

{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Auction, AuctionDTO>()
                .IncludeMembers(x => x.Item).ReverseMap();

            // zamiast reverse map
            // CreateMap<Item, AuctionDTO>();

            CreateMap<CreateAuctionDTO, Auction>()
                .ForMember(d => d.Item, o => o.MapFrom(s => s)).ReverseMap();

            CreateMap<CreateAuctionDTO, Item>();
        }
    }
}
