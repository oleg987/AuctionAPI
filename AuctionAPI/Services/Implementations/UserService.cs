using AuctionAPI.Contracts.Requests.Users;
using AuctionAPI.Contracts.Responses;
using AuctionAPI.Models;
using AuctionAPI.Repositories.Abstractions;
using AuctionAPI.Services.Abstractions;

namespace AuctionAPI.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UserResponse?> GetById(Guid id, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetById(id, cancellationToken);
        
        if (user is not null)
        {
            var response = new UserResponse(user.Id, user.Email, user.Name);

            return response;
        }
        
        return null;
    }

    public async Task<UserResponse> Create(UserCreateRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.FullName) || string.IsNullOrWhiteSpace(request.Email))
        {
            throw new ArgumentException();
        }
        
        var user = new User()
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            Name = request.FullName
        };

        var id = await _unitOfWork.UserRepository.Create(user, cancellationToken);

        var createdUser = await _unitOfWork.UserRepository.GetById(id, cancellationToken);
        
        _unitOfWork.Commit();

        if (createdUser is null)
        {
            throw new ArgumentException();
        }
        
        var response = new UserResponse(createdUser.Id, createdUser.Email, createdUser.Name);
        
        return response;
    }
}