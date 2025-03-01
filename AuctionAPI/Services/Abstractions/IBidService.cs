using AuctionAPI.Contracts.Requests.Bids;
using AuctionAPI.Contracts.Responses.Bids;

namespace AuctionAPI.Services.Abstractions;

public interface IBidService
{
    Task<IEnumerable<BidResponse>> GetByAuctionId(Guid auctionId, CancellationToken cancellationToken);
    Task<BidResponse> PlaceBid(BidCreateRequest request, CancellationToken cancellationToken);
}