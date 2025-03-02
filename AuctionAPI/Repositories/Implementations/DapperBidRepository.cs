using System.Data;
using AuctionAPI.Models;
using AuctionAPI.Repositories.Abstractions;
using Dapper;

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

    public async Task<IEnumerable<Bid>> GetByAuctionId(Guid auctionId, CancellationToken cancellationToken)
    {
        var sql = $@"
                select b.* from {_table} as b
                    join lots as l on l.id = b.lot_id
                    join auctions as a on a.id = l.auction_id
                order by b.created_at desc
                where a.id = @AuctionId;";

        return await _connection.QueryAsync<Bid>(sql, new { AuctionId = auctionId }, _transaction);
    }

    public async Task PlaceBid(Bid entity, CancellationToken cancellationToken)
    {
        var sql = $"insert into {_table} (user_id, lot_id, price, created_at) values (@UserId, @LotId, @Price, @CreatedAt);";

        await _connection.ExecuteScalarAsync(sql, entity, _transaction);
    }

    public async Task<Bid?> GetLastBidByAuctionId(Guid auctionId, CancellationToken cancellationToken)
    {
        var sql = $@"
                select top 1 b.* from {_table} as b
                    join lots as l on l.id = b.lot_id
                    join auctions as a on a.id = l.auction_id
                order by b.created_at desc
                where a.id = @AuctionId;";

        return await _connection.QueryFirstOrDefaultAsync<Bid>(sql, new { AuctionId = auctionId }, _transaction);
    }
}