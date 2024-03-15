using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class AuctionRepository(AuctionDbContext context) : IAuctionRepository
    {
        private readonly AuctionDbContext _context = context;

        public bool Any(Guid id)
        {
            return _context.Auctions.Any(a => a.Id == id);
        }

        public Guid Delete(Guid id)
        {
            var entity = GetById(id);
            _context.Remove(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public IQueryable<Auction> GetAll()
        {
            return _context.Auctions;
        }

        public Auction GetById(Guid id)
        {
            return _context.Auctions.First(a => a.Id == id);
        }

        public void Update(Auction auction)
        {
            throw new NotImplementedException();
        }
    }
}
