namespace AuctionAPI.Contracts.Requests.Auctions;

public record AuctionUpdateRequest(string Title, DateTime Start, DateTime End);