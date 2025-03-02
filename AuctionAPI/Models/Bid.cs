namespace AuctionAPI.Models;

public class Bid
{
    public Guid Id { get; set; }
    public Guid LotId { get; set; }
    public Guid UserId { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
}