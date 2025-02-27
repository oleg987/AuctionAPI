namespace AuctionAPI.Contracts.Requests.Lots;

public record LotCreateRequest(Guid AuctionId, string Title, string Description, decimal StartPrice);