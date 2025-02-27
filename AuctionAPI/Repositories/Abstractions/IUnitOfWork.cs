namespace AuctionAPI.Repositories.Abstractions;

public interface IUnitOfWork : IDisposable
{
    IAuctionRepository AuctionRepository { get; }
    void Commit();
    void Rollback();
}