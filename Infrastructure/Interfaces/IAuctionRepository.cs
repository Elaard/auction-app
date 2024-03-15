using Infrastructure.Entities;

namespace Infrastructure.Interfaces
{
    public interface IAuctionRepository
    {
        bool Any(Guid id);
        Auction GetById(Guid id);
        Guid Delete(Guid id);
        Auction Update(Auction auction);
        Auction Create(Auction auction);
        IQueryable<Auction> GetAll();
    }
}
