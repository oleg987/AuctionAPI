using AuctionAPI.Contracts.Requests.Auctions;
using AuctionAPI.Contracts.Responses.Auctions;
using Microsoft.AspNetCore.Mvc;

namespace AuctionAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
public class AuctionController : ControllerBase
{
    [HttpGet("{id:guid}")]
    [ProducesResponseType(200, Type = typeof(AuctionResponse))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<AuctionResponse>))]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [ProducesResponseType(200, Type = typeof(AuctionResponse))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Post(AuctionCreateRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(200, Type = typeof(AuctionResponse))]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Put(Guid id, AuctionUpdateRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(200, Type = typeof(AuctionResponse))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}