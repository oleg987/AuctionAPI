using AuctionAPI.Models;

namespace AuctionAPI.Repositories.Abstractions;

public interface IUserRepository
{
    Task<User?> GetById(Guid id, CancellationToken cancellationToken);
    Task<Guid> Create(User entity, CancellationToken cancellationToken);
}