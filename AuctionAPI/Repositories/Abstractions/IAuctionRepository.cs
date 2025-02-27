using AuctionAPI.Models;

namespace AuctionAPI.Repositories.Abstractions;

public interface IAuctionRepository
{
    Task<Guid> Create(Auction entity);
    Task<Auction> GetById(Guid id);
    Task<IEnumerable<Auction>> GetAll();
    Task Update(Auction entity);
    Task Delete(Guid id);

}