using AuctionAPI.Contracts.Requests.Bids;
using AuctionAPI.Contracts.Responses.Bids;
using AuctionAPI.Repositories.Abstractions;
using AuctionAPI.Services.Abstractions;

namespace AuctionAPI.Services.Implementations;

public class BidService : IBidService
{
    private readonly IUnitOfWork _unitOfWork;

    public BidService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<BidResponse>> GetByAuctionId(Guid auctionId, CancellationToken cancellationToken)
    {
        return null;
    }

    public async Task<BidResponse> PlaceBid(BidCreateRequest request, CancellationToken cancellationToken)
    {
        return null;
    }
}