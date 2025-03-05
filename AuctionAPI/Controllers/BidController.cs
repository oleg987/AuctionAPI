using AuctionAPI.Contracts.Requests.Bids;
using AuctionAPI.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AuctionAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BidController : ControllerBase
{
    private readonly IBidService _bidService;

    public BidController(IBidService bidService)
    {
        _bidService = bidService;
    }

    [HttpGet("{auctionId:guid}")]
    public async Task<IActionResult> Get(Guid auctionId, CancellationToken cancellationToken)
    {
        var model = await _bidService.GetByAuctionId(auctionId, cancellationToken);

        return Ok(model);
    }

    [HttpPost]
    public async Task<IActionResult> Post(BidCreateRequest request, CancellationToken cancellationToken)
    {
        var model = await _bidService.PlaceBid(request, cancellationToken);

        return Ok(model);
    }
}