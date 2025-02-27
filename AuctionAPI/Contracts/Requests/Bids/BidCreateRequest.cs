namespace AuctionAPI.Contracts.Requests.Bids;

public record BidCreateRequest(Guid LotId, Guid UserId, decimal Price);