namespace AuctionAPI.Models;

public class Item
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public decimal Price { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime BuyAt { get; set; }
}