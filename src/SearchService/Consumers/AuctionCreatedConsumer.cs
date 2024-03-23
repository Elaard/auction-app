using AutoMapper;
using Contracts;
using MassTransit;
using Raven.Client.Documents.Session;
using SearchService.Data;
using SearchService.Models;

namespace SearchService.Consumers
{
    public class AuctionCreatedConsumer(IMapper mapper) : IConsumer<AuctionCreated>
    {
        private readonly IMapper _mapper = mapper;

        public async Task Consume(ConsumeContext<AuctionCreated> context)
        {
            var item = _mapper.Map<Subject>(context.Message);

            using IAsyncDocumentSession session = RavenDbStore.Store.OpenAsyncSession();

            await session.StoreAsync(item);
            await session.SaveChangesAsync();
        }
    }
}
