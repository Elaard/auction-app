using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using SearchService.Data;
using SearchService.Models;
using SearchService.Requests;
using SearchService.Responses;

namespace SearchService.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController() : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<SubjectResponse>> SearchItems([FromQuery] SearchParams searchParams)
        {
            using IDocumentSession session = RavenDbStore.Store.OpenSession();

            IQueryable<Subject> query = session.Query<Subject>()
                .OrderBy(x => x.Make);

            if (!String.IsNullOrEmpty(searchParams.SearchTerm))
            {
                query = query.Search(x => x.Make, searchParams.SearchTerm);
            }

            query = searchParams.OrderBy switch
            {
                "make" => query.OrderBy(x => x.Make),
                "new" => query.OrderByDescending(x => x.CreatedAt),
                _ => query.OrderBy(x => x.AuctionEnd)
            };

            if (!string.IsNullOrEmpty(searchParams.Seller))
            {
                query = query.Where(x => x.Seller == searchParams.Seller);
            }

            if (!string.IsNullOrEmpty(searchParams.Winner))
            {
                query = query.Where(x => x.Winner == searchParams.Winner);
            }


            var totalCount = session.Query<Subject>().Count();
            var results = query
                .Skip(searchParams.PageSize * (searchParams.PageNumber - 1))
                .Take(searchParams.PageSize)
                .ToList();

            return Ok(new
            {
                results,
                pageCount = (int)Math.Ceiling((double)totalCount / searchParams.PageSize),
                totalCount
            });
        }
    }
}
