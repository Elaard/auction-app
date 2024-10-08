﻿using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class SubjectRepository(AuctionDbContext context) : ISubjectRepository
    {
        private readonly AuctionDbContext _context = context;

        public Subject GetById(Guid id)
        {
            return _context.Subjects.First(x => x.Id == id);
        }

        public void Update(Subject subject)
        {
            var original = GetById(subject.Id);
            original.Make = subject.Make ?? original.Make;
            original.Model = subject.Model ?? original.Model;
            original.Color = subject.Color ?? original.Color;
            original.Mileage = subject.Mileage ?? original.Mileage;
            original.Year = subject.Year ?? original.Year;
        }
    }
}
