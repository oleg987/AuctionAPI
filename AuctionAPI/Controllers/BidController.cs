using AuctionAPI.Contracts.Requests.Bids;
using Microsoft.AspNetCore.Mvc;

namespace AuctionAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BidController : ControllerBase
{
    [HttpGet("{auctionId:guid}")]
    public async Task<IActionResult> Get(Guid auctionId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> Post(BidCreateRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}