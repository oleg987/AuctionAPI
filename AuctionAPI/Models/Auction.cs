namespace AuctionAPI.Models;

public class Auction
{
    public Guid Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}