using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using SearchService.Models;
using SearchService.Requests;
using SearchService.Responses;

namespace SearchService.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController(IDocumentSession session) : ControllerBase
    {
        private readonly IDocumentSession _session = session;

        [HttpGet]
        public async Task<ActionResult<List<SubjectResponse>>> SearchItems([FromQuery] SearchParams searchParams)
        {
            IQueryable<Subject> query = session.Query<Subject>()
                .OrderBy(x => x.Make);

            if (!String.IsNullOrEmpty(searchParams.SearchTerm))
            {
                query = query.Search(x => x.Make, searchParams.SearchTerm);
            }

            query = searchParams.FilterBy switch
            {
                "finished" => query.Where(x => DateTime.Parse(x.AuctionEnd) < DateTime.UtcNow),
                "endingSoon" => query.Where(x => DateTime.Parse(x.AuctionEnd) > DateTime.UtcNow && DateTime.Parse(x.AuctionEnd) < DateTime.UtcNow.AddHours(6)),
                _ => query.Where(x => DateTime.Parse(x.AuctionEnd) > DateTime.UtcNow)
            };

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

            var totalCount = await query.CountAsync();
            var results = await query
                .Skip(searchParams.PageSize * (searchParams.PageNumber - 1))
                .Take(searchParams.PageSize)
                .ToListAsync();

            return Ok(new
            {
                results,
                pageCount = (int)Math.Ceiling((double)totalCount / searchParams.PageSize),
                totalCount
            });
        }
    }
}
