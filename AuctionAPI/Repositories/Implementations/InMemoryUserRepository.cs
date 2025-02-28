using AuctionAPI.Models;
using AuctionAPI.Repositories.Abstractions;

namespace AuctionAPI.Repositories.Implementations;

public class InMemoryUserRepository : IUserRepository
{
    private static readonly Dictionary<Guid, User> _users = [];

    public Task<User?> GetById(Guid id, CancellationToken cancellationToken)
    {
        if (_users.TryGetValue(id, out User? user))
        {
            return Task.FromResult<User?>(user);
        }
        
        return Task.FromResult<User?>(null);
    }

    public Task<Guid> Create(User entity, CancellationToken cancellationToken)
    {
        _users.Add(entity.Id, entity);
        
        return Task.FromResult(entity.Id);
    }
}