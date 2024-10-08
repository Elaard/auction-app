﻿using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AuctionRepository(AuctionDbContext context) : IAuctionRepository
    {
        private readonly AuctionDbContext _context = context;

        public bool Any(Guid id)
        {
            return _context.Auctions.Any(a => a.Id == id);
        }

        public Auction Create(Auction auction)
        {
            _context.Auctions.Add(auction);
            return auction;
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
            return _context.Auctions.Include(a => a.Subject);
        }

        public Auction GetById(Guid id)
        {
            return _context.Auctions.Include(a => a.Subject).First(a => a.Id == id);
        }

        public Auction Update(Auction model)
        {
            var auction = GetById(model.Id);

            auction.Subject.Make = model.Subject.Make ?? auction.Subject.Make;
            auction.Subject.Model = model.Subject.Model ?? auction.Subject.Model;
            auction.Subject.Color = model.Subject.Color ?? auction.Subject.Color;
            auction.Subject.Mileage = model.Subject.Mileage ?? auction.Subject.Mileage;
            auction.Subject.Year = model.Subject.Year ?? auction.Subject.Year;

            _context.SaveChanges();

            return auction;
        }
    }
}
