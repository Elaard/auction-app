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

            return _auctionRepository.Create(auction);
        }

        public Guid Delete(Guid id)
        {
            return _auctionRepository.Delete(id);
        }

        public IList<Auction> GetAll(string? date)
        {
            var query = _auctionRepository
                .GetAll()
                .OrderBy(auction => auction.Subject.Make);

            if (date is not null)
            {
                query = (IOrderedQueryable<Auction>)query
                    .Where(a => a.UpdatedAt.CompareTo(DateTime.Parse(date).ToUniversalTime()) > 0);
            }

            return query.ToList();
        }

        public Auction GetById(Guid id)
        {
            return _auctionRepository.GetById(id);
        }

        public void Save()
        {
            _auctionRepository.Save();
        }

        public Auction Update(Guid id, UpdateAuctionDTO model)
        {
            var auction = new Auction()
            {
                Id = id,
                Subject = new Subject()
                {
                    Model = model.Model,
                    Year = model.Year,
                    Color = model.Color,
                    Mileage = model.Mileage,
                    ImageUrl = model.ImageUrl,
                }
            };

            return _auctionRepository.Update(auction);
        }
    }
}
