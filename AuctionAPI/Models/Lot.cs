namespace AuctionAPI.Models;

public class Lot
{
    public Guid Id { get; set; }
    public Guid AuctionId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal StartPrice { get; set; }
}