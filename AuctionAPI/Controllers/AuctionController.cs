using AuctionAPI.Contracts.Requests.Auctions;
using AuctionAPI.Contracts.Responses.Auctions;
using AuctionAPI.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AuctionAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
public class AuctionController : ControllerBase
{
    private readonly IAuctionService _auctionService;

    public AuctionController(IAuctionService auctionService)
    {
        _auctionService = auctionService;
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(200, Type = typeof(AuctionResponse))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var model = await _auctionService.GetById(id, cancellationToken);

        return Ok(model);
    }
    
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<AuctionResponse>))]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var models = await _auctionService.GetAll(cancellationToken);

        return Ok(models);
    }

    [HttpPost]
    [ProducesResponseType(200, Type = typeof(AuctionResponse))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Post(AuctionCreateRequest request, CancellationToken cancellationToken)
    {
        var model = await _auctionService.Create(request, cancellationToken);

        return Ok(model);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(200, Type = typeof(AuctionResponse))]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Put(Guid id, AuctionUpdateRequest request, CancellationToken cancellationToken)
    {
        var model = await _auctionService.Update(id, request, cancellationToken);

        return Ok(model);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(200, Type = typeof(AuctionResponse))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var model = await _auctionService.Delete(id, cancellationToken);

        return Ok(model);
    }
}