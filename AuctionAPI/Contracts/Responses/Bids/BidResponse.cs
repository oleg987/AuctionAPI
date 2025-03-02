namespace AuctionAPI.Contracts.Responses.Bids;

public record BidResponse(Guid Id, Guid LotId, Guid UserId, decimal Price, DateTime CreatedAt);