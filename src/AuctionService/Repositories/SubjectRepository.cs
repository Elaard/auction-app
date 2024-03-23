using AuctionService.Entities;
using AuctionService.Interfaces;

namespace AuctionService.Repositories
{
    public class SubjectRepository(AuctionDbContext context) : ISubjectRepository
    {
        private readonly AuctionDbContext _context = context;

        public Subject GetById(Guid id)
        {
            return _context.Subjects.First(x => x.Id == id);
        }

        public Subject Update(Subject subject)
        {
            var original = GetById(subject.Id);

            original.Make = subject.Make ?? original.Make;
            original.Model = subject.Model ?? original.Model;
            original.Color = subject.Color ?? original.Color;
            original.Mileage = subject.Mileage ?? original.Mileage;
            original.Year = subject.Year ?? original.Year;

            return original;
        }
    }
}
