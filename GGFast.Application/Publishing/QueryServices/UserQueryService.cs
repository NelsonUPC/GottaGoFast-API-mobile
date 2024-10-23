using AutoMapper;
using GottaGoFast.Domain.Publishing.Models.Entities;
using GottaGoFast.Domain.Publishing.Models.Queries;
using GottaGoFast.Domain.Publishing.Models.Response;
using GottaGoFast.Domain.Publishing.Repositories;
using GottaGoFast.Domain.Publishing.Services;

namespace GottaGoFast.Application.QueryServices;

public class UserQueryService : IUserQueryService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserQueryService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<List<UserResponse>?> Handle(GetAllUsersQuery query)
    {
        var data = await _userRepository.GetAllAsync();
        var result = _mapper.Map<List<User>, List<UserResponse>>(data);

        return result;
    }

    public async Task<UserResponse?> Handle(GetUserByIdQuery query)
    {
        var data = await _userRepository.GetByIdAsync(query.Id);
        var result = _mapper.Map<User, UserResponse>(data);
        return result;
    }
}