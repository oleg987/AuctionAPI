namespace AuctionAPI.Contracts.Requests.Lots;

public record LotUpdateRequest(string Title, string Description, decimal StartPrice);