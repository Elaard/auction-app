using Contracts;
using MassTransit;
using Raven.Client.Documents.Session;
using SearchService.Data;
using SearchService.Models;

namespace SearchService.Consumers
{
    public class AuctionFinishedConsumer : IConsumer<AuctionFinished>
    {
        public async Task Consume(ConsumeContext<AuctionFinished> context)
        {
            using IAsyncDocumentSession session = RavenDbStore.Store.OpenAsyncSession();

            var auction = await session.LoadAsync<Subject>(context.Message.AuctionId);

            if (context.Message.ItemSold)
            {
                auction.Winner = context.Message.Winner;
                auction.SoldAmount = (int)context.Message.Amount;
            }

            auction.Status = "Finished";

            await session.SaveChangesAsync();
        }
    }
}
