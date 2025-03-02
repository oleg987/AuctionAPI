using AuctionAPI.Contracts.Requests.Auctions;
using AuctionAPI.Contracts.Responses.Auctions;

namespace AuctionAPI.Services.Abstractions;

public interface IAuctionService
{
    Task<AuctionResponse?> Create(AuctionCreateRequest request, CancellationToken cancellationToken);
    Task<AuctionResponse> GetById(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<AuctionResponse>> GetAll(CancellationToken cancellationToken);
    Task<AuctionResponse> Update(Guid id, AuctionUpdateRequest request, CancellationToken cancellationToken);
    Task<AuctionResponse> Delete(Guid id, CancellationToken cancellationToken);
}