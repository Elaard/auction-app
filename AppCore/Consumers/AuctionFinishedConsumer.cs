﻿using Contracts;
using Infrastructure;
using Infrastructure.Entities;
using MassTransit;

namespace AppCore.Consumers
{
    public class AuctionFinishedConsumer(AuctionDbContext context) : IConsumer<AuctionFinished>
    {
        private readonly AuctionDbContext _context = context;

        public async Task Consume(ConsumeContext<AuctionFinished> context)
        {
            var auction = await _context.Auctions.FindAsync(context.Message.AuctionId);

            if (context.Message.ItemSold)
            {
                auction.Winner = context.Message.Winner;
                auction.SoldAmount = context.Message.Amount;
            }

            auction.Status = auction.SoldAmount > auction.ReservePrice ? Status.Finished : Status.ReserveNotMet;

            await _context.SaveChangesAsync();
        }
    }
}
