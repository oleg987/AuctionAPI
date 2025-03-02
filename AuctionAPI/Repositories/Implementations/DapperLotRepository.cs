using System.Data;
using AuctionAPI.Models;
using AuctionAPI.Repositories.Abstractions;
using Dapper;

namespace AuctionAPI.Repositories.Implementations;

public class DapperLotRepository : ILotRepository
{
    private readonly IDbConnection _dbConnection;
    private readonly IDbTransaction _transaction;

    private const string _table = "lots";

    public DapperLotRepository(IDbConnection dbConnection, IDbTransaction transaction)
    {
        _dbConnection = dbConnection;
        _transaction = transaction;
    }

    public async Task<Lot?> GetById(Guid id, CancellationToken cancellationToken)
    {
        var sql = $"select id, auction_id as AuctionId, title, description, start_price as StartPrice from {_table} where id = @Id;";
        
        return await _dbConnection.QuerySingleOrDefaultAsync<Lot>(sql, new { Id = id }, _transaction);
    }

    public async Task<IEnumerable<Lot>> GetAll(CancellationToken cancellationToken)
    {
        var sql = $"select * from {_table};";

        return await _dbConnection.QueryAsync<Lot>(sql, transaction: _transaction);
    }

    public async Task<Guid> Create(Lot entity, CancellationToken cancellationToken)
    {
        var sql = $"insert into {_table} (id, auction_id, title, description, start_price) values (@Id, @AuctionId, @Title, @Description, @StartPrice) returning id;";

        return await _dbConnection.ExecuteScalarAsync<Guid>(sql, entity, _transaction);
    }

    public async Task Update(Lot entity, CancellationToken cancellationToken)
    {
        var sql = $@"update {_table} 
                        set auction_id = @AuctionId,
                            title = @Title,
                            description = @Description,
                            start_price = @StartPrice
                            where id = @Id;";

        await _dbConnection.ExecuteScalarAsync(sql, entity, _transaction);
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        var sql = $"delete from {_table} where id = @Id;";

        await _dbConnection.ExecuteScalarAsync(sql, new { Id = id }, _transaction);
    }
}