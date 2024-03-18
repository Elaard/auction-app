using AutoMapper;
using Contracts;
using MassTransit;
using Raven.Client.Documents.Session;
using SearchService.Data;
using SearchService.Models;

namespace SearchService.Consumers
{
    public class AuctionUpdatedConsumer(IMapper mapper) : IConsumer<AuctionUpdated>
    {
        private readonly IMapper _mapper = mapper;

        public async Task Consume(ConsumeContext<AuctionUpdated> context)
        {
            using IAsyncDocumentSession session = RavenDbStore.Store.OpenAsyncSession();

            var entity = await session.LoadAsync<Subject>(context.Message.Id);

            entity.Make = context.Message.Make;
            entity.Model = context.Message.Model;
            entity.Year = context.Message.Year;
            entity.Color = context.Message.Color;
            entity.Mileage = context.Message.Mileage;

            await session.SaveChangesAsync();
        }
    }
}
