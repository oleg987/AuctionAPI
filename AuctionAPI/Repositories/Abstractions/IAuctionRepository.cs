﻿using AuctionAPI.Models;

namespace AuctionAPI.Repositories.Abstractions;

public interface IAuctionRepository
{
    Task<Guid> Create(Auction entity, CancellationToken cancellationToken);
    Task<Auction?> GetById(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Auction>> GetPast(CancellationToken cancellationToken);
    Task<IEnumerable<Auction>> GetActive(CancellationToken cancellationToken);
    Task<IEnumerable<Auction>> GetFuture(CancellationToken cancellationToken);
    Task Update(Auction entity, CancellationToken cancellationToken);
    Task Delete(Guid id, CancellationToken cancellationToken);

}