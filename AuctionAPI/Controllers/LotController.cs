using AuctionAPI.Contracts.Requests.Lots;
using AuctionAPI.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AuctionAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class LotController : ControllerBase
{
    private readonly ILotService _lotService;

    public LotController(ILotService lotService)
    {
        _lotService = lotService;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var model = await _lotService.GetById(id, cancellationToken);

        if (model is not null)
        {
            return Ok(model);
        }

        return NotFound();
    }
    
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var models = await _lotService.GetAll(cancellationToken);

        return Ok(models);
    }

    [HttpPost]
    public async Task<IActionResult> Post(LotCreateRequest request, CancellationToken cancellationToken)
    {
        var model = await _lotService.Create(request, cancellationToken);

        if (model is not null)
        {
            return Ok(model);
        }

        return BadRequest();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, LotUpdateRequest request, CancellationToken cancellationToken)
    {
        var model = await _lotService.Update(id, request, cancellationToken);

        if (model is not null)
        {
            return Ok(model);
        }

        return BadRequest();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var model = await _lotService.Delete(id, cancellationToken);

        if (model is not null)
        {
            return Ok(model);
        }

        return BadRequest();
    }
}