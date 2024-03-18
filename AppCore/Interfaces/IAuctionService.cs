using AuctionService.DTOs;
using Infrastructure.Entities;

namespace AppCore.Interfaces
{
    public interface IAuctionService
    {
        IList<Auction> GetAll(string? date);
        Auction GetById(Guid id);
        Auction Create(CreateAuctionDTO auction);
        Guid Delete(Guid id);
        Auction Update(Guid id, UpdateAuctionDTO auction);
        void Save();
    }
}
