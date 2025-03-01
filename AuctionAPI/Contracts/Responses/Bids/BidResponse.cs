namespace AuctionAPI.Contracts.Responses.Bids;

public record BidResponse(Guid LotId, Guid UserId, decimal Price, DateTime CreatedAt);