using AuctionAPI.Contracts.Requests.Users;
using AuctionAPI.Contracts.Responses;
using AuctionAPI.Contracts.Responses.Users;

namespace AuctionAPI.Services.Abstractions;

public interface IUserService
{
    Task<UserResponse?> GetById(Guid id, CancellationToken cancellationToken);
    Task<UserResponse> Create(UserCreateRequest request, CancellationToken cancellationToken);
}