using AuctionAPI.Contracts.Requests.Bids;
using AuctionAPI.Contracts.Responses.Bids;
using AuctionAPI.Models;
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
        var bids = await _unitOfWork.BidRepository.GetByAuctionId(auctionId, cancellationToken);
        
        return bids.Select(bid => new BidResponse(bid.Id, bid.LotId, bid.UserId, bid.Price, bid.CreatedAt));
    }

    public async Task<BidResponse?> PlaceBid(BidCreateRequest request, CancellationToken cancellationToken)
    {
        var lot = await _unitOfWork.LotRepository.GetById(request.LotId, cancellationToken);

        if (lot is null || lot.StartPrice > request.Price)
        {
            return null;
        }

        var auction = await _unitOfWork.AuctionRepository.GetById(lot.AuctionId, cancellationToken);

        if (auction is null || auction.Start < DateTime.Now || auction.Finish > DateTime.Now)
        {
            return null;
        }

        var lastBid = await _unitOfWork.BidRepository.GetLastBidByAuctionId(auction.Id, cancellationToken);

        if (lastBid is not null && request.Price < lastBid.Price)
        {
            return null;
        }

        var bid = new Bid()
        {
            Id = Guid.NewGuid(),
            LotId = request.LotId,
            UserId = request.UserId,
            Price = request.Price,
            CreatedAt = DateTime.Now
        };

        await _unitOfWork.BidRepository.PlaceBid(bid, cancellationToken);
        
        _unitOfWork.Commit();
        
        return new BidResponse(bid.Id, bid.LotId, bid.UserId, bid.Price, bid.CreatedAt);
    }
}