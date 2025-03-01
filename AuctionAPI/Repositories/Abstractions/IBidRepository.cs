using AuctionAPI.Models;

namespace AuctionAPI.Repositories.Abstractions;

public interface IBidRepository
{
    Task<IEnumerable<Bid>> GetByAuctionId(Guid auctionId, CancellationToken cancellationToken);
    Task PlaceBid(Bid request, CancellationToken cancellationToken);
}