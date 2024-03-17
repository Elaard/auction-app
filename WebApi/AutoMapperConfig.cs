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
        }
    }
}
