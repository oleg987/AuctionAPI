namespace AuctionAPI.Contracts.Responses.Lots;

public record LotResponse(
    Guid Id, 
    Guid AuctionId, 
    string Title, 
    string Description, 
    decimal StartPrice);