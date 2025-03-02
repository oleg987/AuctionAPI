using AuctionAPI.Models;
using AuctionAPI.Repositories.Abstractions;

namespace AuctionAPI.Repositories.Implementations;

public class InMemoryAuctionRepository : IAuctionRepository
{
    private static readonly List<Auction> _storage = [];
    
    public Task<Guid> Create(Auction entity, CancellationToken cancellationToken)
    {
        entity.Id = Guid.NewGuid();
        _storage.Add(entity);

        return Task.FromResult(entity.Id);
    }

    public Task<Auction?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return Task.FromResult(_storage.FirstOrDefault(a => a.Id == id));
    }

    public Task<IEnumerable<Auction>> GetAll(CancellationToken cancellationToken)
    {
        return Task.FromResult<IEnumerable<Auction>>(_storage);
    }

    public Task Update(Auction entity, CancellationToken cancellationToken)
    {
        var record = _storage.First(r => r.Id == entity.Id);

        _storage.Remove(record);
        
        _storage.Add(entity);
        
        return Task.CompletedTask;
    }

    public Task Delete(Guid id, CancellationToken cancellationToken)
    {
        var record = _storage.First(r => r.Id == id);
        
        _storage.Remove(record);
        
        return Task.CompletedTask;
    }
}