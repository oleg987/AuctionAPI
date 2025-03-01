using System.Data;
using AuctionAPI.Models;
using AuctionAPI.Repositories.Abstractions;

namespace AuctionAPI.Repositories.Implementations;

public class DapperBidRepository : IBidRepository
{
    private readonly IDbConnection _connection;
    private readonly IDbTransaction _transaction;

    private const string _table = "bids";

    public DapperBidRepository(IDbConnection connection, IDbTransaction transaction)
    {
        _connection = connection;
        _transaction = transaction;
    }

    public Task<IEnumerable<Bid>> GetByAuctionId(Guid auctionId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task PlaceBid(Bid request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}