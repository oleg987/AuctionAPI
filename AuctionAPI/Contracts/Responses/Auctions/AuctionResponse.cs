namespace AuctionAPI.Contracts.Responses.Auctions;

public record AuctionResponse(Guid Id, string Title, DateTime Start, DateTime End);