using AppCore.Interfaces;
using AuctionService.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AuctionService.Controllers
{
    [ApiController]
    [Route("api/auctions")]
    public class AuctionsController(IMapper mapper, IAuctionService auctionService) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly IAuctionService _auctionService = auctionService;

        [HttpGet]
        public ActionResult<List<AuctionDTO>> GetList(string? date)
        {
            var auctions = _auctionService.GetAll(date);
            return _mapper.Map<List<AuctionDTO>>(auctions);
        }

        [HttpGet("{id}")]
        public ActionResult<AuctionDTO> GetAuctionById(Guid id)
        {
            var auction = _auctionService.GetById(id);

            if (auction is null)
            {
                return NotFound();
            }

            return _mapper.Map<AuctionDTO>(auction);
        }

        [HttpPost]
        public ActionResult<AuctionDTO> CreateAuction(CreateAuctionDTO auctionDto)
        {
            var result = _auctionService.Create(auctionDto);

            return CreatedAtAction(nameof(GetAuctionById), new { result.Id }, _mapper.Map<AuctionDTO>(result));
        }

        [HttpPut("{id}")]
        public ActionResult<AuctionDTO> UpdateAuction(Guid id, UpdateAuctionDTO model)
        {
            var result = _auctionService.Update(id, model);

            if (result is null)
            {
                return NotFound();
            };

            return Ok(_mapper.Map<AuctionDTO>(result));
        }

        [HttpDelete("{id}")]
        public ActionResult<Guid> DeleteAuction(Guid id)
        {
            var result = _auctionService.Delete(id);
            return Ok(result);
        }
    }
}
