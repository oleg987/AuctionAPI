namespace AuctionAPI.Contracts.Responses.Auctions;

public record AuctionResponse(Guid Id, DateTime Start, DateTime End);