using AuctionAPI.Contracts.Requests.Lots;
using Microsoft.AspNetCore.Mvc;

namespace AuctionAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class LotController : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> Post(LotCreateRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, LotUpdateRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}