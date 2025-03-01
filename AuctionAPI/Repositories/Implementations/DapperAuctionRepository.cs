using System.Data;
using AuctionAPI.Models;
using AuctionAPI.Repositories.Abstractions;
using Dapper;

namespace AuctionAPI.Repositories.Implementations;

public class DapperAuctionRepository : IAuctionRepository
{
    private readonly IDbConnection _connection;
    private readonly IDbTransaction _transaction;
    private const string _table = "auctions";

    public DapperAuctionRepository(IDbConnection connection, IDbTransaction transaction)
    {
        _connection = connection;
        _transaction = transaction;
    }

    public async Task<Guid> Create(Auction entity)
    {
        var sql = $"insert into {_table} (id, title, start, finish) values (@Id, @Title, @Start, @Finish) returning id;";

        return await _connection.ExecuteScalarAsync<Guid>(sql, entity, _transaction);
    }

    public async Task<Auction?> GetById(Guid id)
    {
        var sql = $"select * from {_table} where id = @Id;";

        return await _connection.QuerySingleOrDefaultAsync<Auction>(sql, new {Id = id}, _transaction);
    }

    public async Task<IEnumerable<Auction>> GetAll()
    {
        var sql = $"select * from {_table};";

        return await _connection.QueryAsync<Auction>(sql, transaction: _transaction);
    }

    public async Task Update(Auction entity)
    {
        var sql = $@"update {_table} 
                        set title = @Title,
                            start = @Start,
                            finish = @Finish
                            where id = @Id;";

        await _connection.ExecuteScalarAsync(sql, entity, _transaction);
    }

    public async Task Delete(Guid id)
    {
        var sql = $"delete from {_table} where id = @Id;";

        await _connection.ExecuteScalarAsync(sql, new {Id = id }, _transaction);
    }
}