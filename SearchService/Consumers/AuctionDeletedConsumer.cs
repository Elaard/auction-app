using Contracts;
using MassTransit;
using Raven.Client.Documents.Session;
using SearchService.Data;

namespace SearchService.Consumers
{
    public class AuctionDeletedConsumer : IConsumer<AuctionDeleted>
    {
        public async Task Consume(ConsumeContext<AuctionDeleted> context)
        {
            using IAsyncDocumentSession session = RavenDbStore.Store.OpenAsyncSession();

            session.Delete(context.Message.Id);
            await session.SaveChangesAsync();
        }
    }
}
