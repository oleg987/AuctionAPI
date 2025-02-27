using AuctionAPI.Contracts.Requests.Auctions;
using AuctionAPI.Contracts.Responses.Auctions;
using AuctionAPI.Models;
using AuctionAPI.Repositories.Abstractions;
using AuctionAPI.Services.Abstractions;

namespace AuctionAPI.Services.Implementations;

public class AuctionService : IAuctionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuctionRepository _auctionRepository;

    public AuctionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _auctionRepository = unitOfWork.AuctionRepository;
    }

    public async Task<AuctionResponse> Create(AuctionCreateRequest request, CancellationToken cancellationToken)
    {
        var auction = new Auction()
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Start = request.Start,
            Finish = request.End
        };

        var id = await _auctionRepository.Create(auction);

        var entity = await _auctionRepository.GetById(id);

        _unitOfWork.Commit();
        
        var response = new AuctionResponse(entity.Id, entity.Title, entity.Start, entity.Finish);
        
        return response;
    }

    public async Task<AuctionResponse> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _auctionRepository.GetById(id);

        var response = new AuctionResponse(entity.Id, entity.Title, entity.Start, entity.Finish);
        
        return response;
    }

    public async Task<IEnumerable<AuctionResponse>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _auctionRepository.GetAll();

        var response = new List<AuctionResponse>();

        foreach (var entity in entities)
        {
            response.Add(new AuctionResponse(entity.Id, entity.Title, entity.Start, entity.Finish));
        }

        return response;
    }

    public async Task<AuctionResponse> Update(Guid id, AuctionUpdateRequest request, CancellationToken cancellationToken)
    {
        var entity = await _auctionRepository.GetById(id);

        entity.Title = request.Title;
        entity.Start = request.Start;
        entity.Finish = request.End;

        await _auctionRepository.Update(entity);
        
        var updated = await _auctionRepository.GetById(id);
        
        _unitOfWork.Commit();
        
        var response = new AuctionResponse(updated.Id, updated.Title, updated.Start, updated.Finish);

        return response;
    }

    public async Task<AuctionResponse> Delete(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _auctionRepository.GetById(id);
        
        await _auctionRepository.Delete(id);
        
        _unitOfWork.Commit();
            
        var response = new AuctionResponse(entity.Id, entity.Title, entity.Start, entity.Finish);

        return response;
    }
}