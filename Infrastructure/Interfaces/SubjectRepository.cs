using Infrastructure.Entities;

namespace Infrastructure.Interfaces
{
    public interface ISubjectRepository
    {
        Subject GetById(Guid id);
        void Update(Subject subject);
    }
}
