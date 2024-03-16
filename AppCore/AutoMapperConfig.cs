using AuctionService.DTOs;
using AutoMapper;
using Infrastructure.Entities;

namespace AppCore
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Auction, AuctionDTO>()
                .IncludeMembers(x => x.Subject);

            CreateMap<Subject, AuctionDTO>();

            CreateMap<CreateAuctionDTO, Auction>()
                .ForMember(d => d.Subject, o => o.MapFrom(s => s));

            CreateMap<CreateAuctionDTO, Subject>();
        }
    }
}
