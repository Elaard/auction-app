using Contracts;
using Infrastructure;
using MassTransit;

namespace AppCore.Consumers
{
    public class BidPlacedConsumer(AuctionDbContext context) : IConsumer<AuctionFinished>
    {
        private readonly AuctionDbContext _context = context;

        public async Task Consume(ConsumeContext<AuctionFinished> context)
        {
            var auction = await _context.Auctions.FindAsync(context.Message.AuctionId);

            if (auction is null)
            {
                return;
            }

            if (auction?.CurrentHighBid is null
                || context.Message.BidStatus.Contains("Accepted")
                && context.Message.Amount > auction.CurrentHighBid)
            {
                auction.CurrentHighBid = context.Message.Amount;
                await _context.SaveChangesAsync();
            }

        }
    }
}
