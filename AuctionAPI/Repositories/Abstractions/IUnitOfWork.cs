namespace AuctionAPI.Repositories.Abstractions;

public interface IUnitOfWork : IDisposable
{
    IAuctionRepository AuctionRepository { get; }
    IUserRepository UserRepository { get; }
    ILotRepository LotRepository { get; }
    void Commit();
    void Rollback();
}