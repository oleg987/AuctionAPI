namespace AuctionAPI.Repositories.Abstractions;

public interface IUnitOfWork : IDisposable
{
    IAuctionRepository AuctionRepository { get; }
    IUserRepository UserRepository { get; }
    void Commit();
    void Rollback();
}