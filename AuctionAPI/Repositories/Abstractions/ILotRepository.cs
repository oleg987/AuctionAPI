using AuctionAPI.Models;

namespace AuctionAPI.Repositories.Abstractions;

public interface ILotRepository
{
    Task<Lot?> GetById(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Lot>> GetAll(CancellationToken cancellationToken);
    Task<Guid> Create(Lot entity, CancellationToken cancellationToken);
    Task Update(Lot entity, CancellationToken cancellationToken);
    Task Delete(Guid id, CancellationToken cancellationToken);
}