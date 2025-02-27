using AuctionAPI.Contracts.Requests.Users;
using Microsoft.AspNetCore.Mvc;

namespace AuctionAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> Post(UserCreateRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}