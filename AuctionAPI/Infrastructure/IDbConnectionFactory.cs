using System.Data;

namespace AuctionAPI.Infrastructure;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}