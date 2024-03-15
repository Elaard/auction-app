using Infrastructure.Entities;

namespace Infrastructure.Interfaces
{
    public interface IAuctionRepository
    {
        bool Any(Guid id);
        Auction GetById(Guid id);
        Guid Delete(Guid id);
        void Update(Auction auction);
        IQueryable<Auction> GetAll();
    }
}
