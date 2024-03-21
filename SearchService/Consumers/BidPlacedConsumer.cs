using Contracts;
using MassTransit;
using Raven.Client.Documents.Session;
using SearchService.Data;
using SearchService.Models;

namespace SearchService.Consumers
{
    public class BidPlacedConsumer : IConsumer<BidPlaced>
    {
        public async Task Consume(ConsumeContext<BidPlaced> context)
        {
            using IAsyncDocumentSession session = RavenDbStore.Store.OpenAsyncSession();

            var auction = await session.LoadAsync<Subject>(context.Message.AuctionId);

            if (context.Message.BidStatus.Contains("Accepted")
                && context.Message.Amount > auction.CurrentHighBid)
            {
                auction.CurrentHighBid = context.Message.Amount;

                await session.SaveChangesAsync();
            }

        }
    }
}
