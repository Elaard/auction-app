using AutoMapper;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using SearchService.Models;
using SearchService.Responses;
using SearchService.Services;

namespace SearchService.Data
{
    public static class RavenDbStore
    {
        private static readonly Lazy<IDocumentStore> _lazyStore =
          new(() =>
          {
              var store = new DocumentStore
              {
                  Urls = ["http://localhost:8080"],
                  Database = "search-service-db"
              };

              return store.Initialize();
          });

        public static IDocumentStore Store => _lazyStore.Value;

        public async static void Init(WebApplication builder)
        {
            try
            {
                using IDocumentSession session = Store.OpenSession();

                using var scope = builder.Services.CreateScope();

                var httpClient = scope.ServiceProvider.GetRequiredService<AuctionSvcHttpClient>();
                var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

                var subjects = await httpClient.GetItemsForSearchDb();

                var documents = mapper.Map<List<SubjectResponse>, List<Subject>>(subjects);

                documents.ForEach(document =>
                {
                    session.Store(document);
                });

                session.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
