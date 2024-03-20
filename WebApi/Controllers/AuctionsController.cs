using AppCore.Interfaces;
using AuctionService.DTOs;
using AutoMapper;
using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionService.Controllers
{
    [ApiController]
    [Route("api/auctions")]
    public class AuctionsController(IMapper mapper, IAuctionService auctionService, IPublishEndpoint publishEndpoint) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly IAuctionService _auctionService = auctionService;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

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

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<AuctionDTO>> CreateAuction(CreateAuctionDTO auctionDto)
        {
            auctionDto.Seller = User.Identity.Name;

            var result = _auctionService.Create(auctionDto);

            var newAuction = _mapper.Map<AuctionDTO>(result);

            await _publishEndpoint.Publish(_mapper.Map<AuctionCreated>(newAuction));

            _auctionService.Save();

            return CreatedAtAction(nameof(GetAuctionById), new { result.Id }, _mapper.Map<AuctionDTO>(result));
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<AuctionDTO>> UpdateAuction(Guid id, UpdateAuctionDTO model)
        {
            var result = _auctionService.Update(id, model);
            var auctionDto = _mapper.Map<AuctionDTO>(result);

            await _publishEndpoint.Publish(_mapper.Map<AuctionUpdated>(auctionDto));

            _auctionService.Save();

            return Ok(auctionDto);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> DeleteAuction(Guid id)
        {
            var result = _auctionService.Delete(id);

            await _publishEndpoint.Publish(new AuctionDeleted
            {
                Id = result.ToString()
            });

            _auctionService.Save();

            return Ok(result);
        }
    }
}
