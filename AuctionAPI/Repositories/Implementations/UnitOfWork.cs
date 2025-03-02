using System.Data;
using AuctionAPI.Infrastructure;
using AuctionAPI.Repositories.Abstractions;

namespace AuctionAPI.Repositories.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private readonly IDbConnection _connection;
    private readonly IDbTransaction _transaction;
    private readonly ILogger<UnitOfWork> _logger;

    public IAuctionRepository AuctionRepository { get; }
    public IUserRepository UserRepository { get; }
    public ILotRepository LotRepository { get; }
    public IBidRepository BidRepository { get; }

    public UnitOfWork(IDbConnectionFactory connectionFactory, ILogger<UnitOfWork> logger)
    {
        _logger = logger;
        _connection = connectionFactory.CreateConnection();
        _connection.Open();
        _transaction = _connection.BeginTransaction();

        AuctionRepository = new DapperAuctionRepository(_connection, _transaction);
        UserRepository = new DapperUserRepository(_connection, _transaction);
        LotRepository = new DapperLotRepository(_connection, _transaction);
        BidRepository = new DapperBidRepository(_connection, _transaction);
    }

    public void Commit()
    {
        try
        {
            _transaction.Commit();
        }
        catch
        {
            _transaction.Rollback();
            throw;
        }
        finally
        {
            _transaction.Dispose();
            _connection.Dispose();
        }
    }

    public void Rollback()
    {
        _transaction.Rollback();
        _transaction.Dispose();
        _connection.Dispose();
    }
    
    public void Dispose()
    {
        _transaction.Dispose();
        _connection.Dispose();
    }
}