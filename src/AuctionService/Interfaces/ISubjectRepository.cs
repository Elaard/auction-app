using AuctionService.Entities;

namespace AuctionService.Interfaces
{
    public interface ISubjectRepository
    {
        Subject GetById(Guid id);
        Subject Update(Subject subject);
    }
}
