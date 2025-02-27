namespace AuctionAPI.Contracts.Requests.Auctions;

public record AuctionCreateRequest(string Title, DateTime Start, DateTime End);