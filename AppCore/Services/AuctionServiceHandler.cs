using AppCore.Interfaces;
using AuctionService.DTOs;
using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace AppCore.Services
{
    public class AuctionServiceHandler(IAuctionRepository auctionRepository, IMapper mapper) : IAuctionService
    {
        private readonly IAuctionRepository _auctionRepository = auctionRepository;
        private readonly IMapper _mapper = mapper;

        public Auction Create(CreateAuctionDTO model)
        {
            var auction = _mapper.Map<Auction>(model);

            auction.Seller = "test";

            return _auctionRepository.Create(auction);
        }

        public Guid Delete(Guid id)
        {
            return _auctionRepository.Delete(id);
        }

        public IList<Auction> GetAll()
        {
            return _auctionRepository.GetAll()
                .ToList();
        }

        public Auction GetById(Guid id)
        {
            return _auctionRepository.GetById(id);
        }

        public Auction Update(Guid id, UpdateAuctionDTO model)
        {
            var auction = _mapper.Map<Auction>(model);

            return _auctionRepository.Update(auction);
        }
    }
}
