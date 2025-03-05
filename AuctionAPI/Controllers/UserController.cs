using AuctionAPI.Contracts.Requests.Users;
using AuctionAPI.Contracts.Responses.Users;
using AuctionAPI.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AuctionAPI.Controllers;

public record SignInRequest(string Email, string Password);

public record SignUpRequest(string Name, string Email, string Password);

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [Route("sign-in")]
    public async Task<IActionResult> SignIn(SignInRequest request, CancellationToken cancellationToken)
    {
        if (request.Email == "test@example.com" && request.Password == "12345")
        {
            return Ok(new { Id = Guid.NewGuid(), Name = "John", Email = "test@example.com" });
        }

        return Unauthorized();
    }
    
    [HttpPost]
    [Route("sign-up")]
    public async Task<IActionResult> SignUp(SignUpRequest request, CancellationToken cancellationToken)
    {
        if (request.Email == "test@example.com" && request.Password == "12345")
        {
            return Ok(new { Id = Guid.NewGuid(), Name = "John", Email = "test@example.com" });
        }
        
        GC.Collect();
        // mark
        // check references
        // collect gen 0
        // check memory
        // collect gen 1
        // check memory
        // collect gen 2
        // check memory
        // collect gen 3/4

        return Unauthorized();
    }
}