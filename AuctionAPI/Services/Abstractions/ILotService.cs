using AuctionAPI.Contracts.Requests.Lots;
using AuctionAPI.Contracts.Responses.Lots;

namespace AuctionAPI.Services.Abstractions;

public interface ILotService
{
    Task<LotResponse?> GetById(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<LotResponse>> GetAll(CancellationToken cancellationToken);
    Task<LotResponse?> Create(LotCreateRequest request, CancellationToken cancellationToken);
    Task<LotResponse?> Update(Guid id, LotUpdateRequest request, CancellationToken cancellationToken);
    Task<LotResponse?> Delete(Guid id, CancellationToken cancellationToken);
}