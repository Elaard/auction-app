using AutoMapper;
using Contracts;
using SearchService.Models;
using SearchService.Responses;

namespace SearchService
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<SubjectResponse, Subject>()
                .ForMember(sr => sr.Id, s => s.MapFrom(d => d.Id.ToString()));

            CreateMap<AuctionCreated, Subject>();
        }
    }
}
