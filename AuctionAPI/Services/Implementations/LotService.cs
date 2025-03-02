using AuctionAPI.Contracts.Requests.Lots;
using AuctionAPI.Contracts.Responses.Lots;
using AuctionAPI.Models;
using AuctionAPI.Repositories.Abstractions;
using AuctionAPI.Services.Abstractions;

namespace AuctionAPI.Services.Implementations;

public class LotService : ILotService
{
    private readonly IUnitOfWork _unitOfWork;

    public LotService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<LotResponse?> GetById(Guid id, CancellationToken cancellationToken)
    {
        var lot = await _unitOfWork.LotRepository.GetById(id, cancellationToken);

        if (lot is not null)
        {
            var response = new LotResponse(lot.Id, lot.AuctionId, lot.Title, lot.Description, lot.StartPrice);

            return response;
        }

        return null;
    }
    
    public async Task<IEnumerable<LotResponse>> GetAll(CancellationToken cancellationToken)
    {
        var lots = await _unitOfWork.LotRepository.GetAll(cancellationToken);

        return lots.Select(lot => new LotResponse(lot.Id, lot.AuctionId, lot.Title, lot.Description, lot.StartPrice));
    }
    
    public async Task<LotResponse?> Create(LotCreateRequest request, CancellationToken cancellationToken)
    {
        var auction = await _unitOfWork.AuctionRepository.GetById(request.AuctionId, cancellationToken);

        if (auction is null || auction.Start < DateTime.Now)
        {
            return null;
        }
        
        var lot = new Lot()
        {
            Id = Guid.NewGuid(),
            AuctionId = request.AuctionId,
            Title = request.Title,
            Description = request.Description,
            StartPrice = request.StartPrice
        };

        var id = await _unitOfWork.LotRepository.Create(lot, cancellationToken);

        var storedLot = await _unitOfWork.LotRepository.GetById(id, cancellationToken);
        
        _unitOfWork.Commit();

        if (storedLot is not null)
        {
            var response = new LotResponse(storedLot.Id, storedLot.AuctionId, storedLot.Title, storedLot.Description, storedLot.StartPrice);

            return response;
        }

        return null;
    }
    
    public async Task<LotResponse?> Update(Guid id, LotUpdateRequest request, CancellationToken cancellationToken)
    {
        var lot = await _unitOfWork.LotRepository.GetById(id, cancellationToken);

        if (lot is null)
        {
            return null;
        }
        
        var auction = await _unitOfWork.AuctionRepository.GetById(lot.AuctionId, cancellationToken);

        if (auction is null || auction.Start < DateTime.Now)
        {
            return null;
        }

        lot.Title = request.Title;
        lot.Description = request.Description;
        lot.StartPrice = request.StartPrice;

        await _unitOfWork.LotRepository.Update(lot, cancellationToken);
        
        var updatedLot = await _unitOfWork.LotRepository.GetById(id, cancellationToken);
        
        _unitOfWork.Commit();

        if (updatedLot is not null)
        {
            return new LotResponse(updatedLot.Id, updatedLot.AuctionId, updatedLot.Title, updatedLot.Description, updatedLot.StartPrice);
        }

        return null;
    }
    
    public async Task<LotResponse?> Delete(Guid id, CancellationToken cancellationToken)
    {
        var lot = await _unitOfWork.LotRepository.GetById(id, cancellationToken);

        if (lot is null)
        {
            return null;
        }
        
        var auction = await _unitOfWork.AuctionRepository.GetById(lot.AuctionId, cancellationToken);

        if (auction is not null && auction.Start < DateTime.Now)
        {
            return null;
        }

        await _unitOfWork.LotRepository.Delete(id, cancellationToken);

        return new LotResponse(lot.Id, lot.AuctionId, lot.Title, lot.Description, lot.StartPrice);
    }
}