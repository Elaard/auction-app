using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using SearchService.Data;
using SearchService.Responses;

namespace SearchService.Services
{
    public class AuctionSvcHttpClient(HttpClient httpClient, IConfiguration config)
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly IConfiguration _config = config;

        public async Task<List<SubjectResponse>> GetItemsForSearchDb()
        {
            using IDocumentSession session = RavenDbStore.Store.OpenSession();
            {
                var lastUpdated = session
                .Query<SubjectResponse>()
                .OrderByDescending(x => x.UpdatedAt)
                .Select(x => x.UpdatedAt.ToString())
                .FirstOrDefault<string>();

                return await _httpClient.GetFromJsonAsync<List<SubjectResponse>>(_config["AuctionServiceUrl"] + "/api/auctions?date=" + lastUpdated);
            }
        }

    }
}
