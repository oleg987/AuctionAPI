using System.Data;
using AuctionAPI.Models;
using AuctionAPI.Repositories.Abstractions;
using Dapper;
using Npgsql;

namespace AuctionAPI.Repositories.Implementations;

public class DapperUserRepository : IUserRepository
{
    private readonly IDbConnection _connection;
    private readonly IDbTransaction _transaction;

    private const string _table = "users";

    public DapperUserRepository(IDbConnection connection, IDbTransaction transaction)
    {
        _connection = connection;
        _transaction = transaction;
    }
    
    public async Task<User?> GetById(Guid id, CancellationToken cancellationToken)
    {
        var sql = $"select * from {_table} where id = @Id;";
        
        var user = await _connection.QuerySingleOrDefaultAsync<User>(sql, new { Id = id }, _transaction);
        
        return user;
    }

    public async Task<Guid> Create(User entity, CancellationToken cancellationToken)
    {
        var sql = $"insert into {_table} (id, name, email) values (@Id, @Name, @Email) returning id;";

        var id = await _connection.ExecuteScalarAsync<Guid>(sql, entity, _transaction);
        
        return id;
    }

}