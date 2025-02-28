using AuctionAPI.Contracts.Requests.Users;
using AuctionAPI.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AuctionAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var response = await _userService.GetById(id, cancellationToken);

        if (response is not null)
        {
            return Ok(response);
        }
        
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Post(UserCreateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _userService.Create(request, cancellationToken);
            return Ok(response);
        }
        catch
        {
            return BadRequest();
        }
    }
}