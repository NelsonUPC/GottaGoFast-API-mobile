using AutoMapper;
using DriveSafe.Domain.Publishing.Models.Queries;
using GottaGoFast.Domain.Publishing.Models.Entities;
using GottaGoFast.Domain.Publishing.Models.Queries;
using GottaGoFast.Domain.Publishing.Models.Response;
using GottaGoFast.Domain.Publishing.Repositories;
using GottaGoFast.Domain.Publishing.Services;

namespace GottaGoFast.Application.QueryServices;

public class RentQueryService : IRentQueryService
{
    private readonly IRentRepository _rentRepository;
    private readonly IMapper _mapper;
    
    public RentQueryService(IRentRepository rentRepository, IMapper mapper)
    {
        _rentRepository = rentRepository;
        _mapper = mapper;
    }
    
    public async Task<List<RentResponse>?> Handle(GetAllRentsQuery query)
    {
        var data = await _rentRepository.GetAllAsync();
        var result = _mapper.Map<List<Rent>, List<RentResponse>>(data);
        return result;
    }
    public async Task<RentResponse?> Handle(GetRentByIdQuery query)
    {
        var data = await _rentRepository.GetByIdAsync(query.Id);
        var result = _mapper.Map<Rent, RentResponse>(data);
        return result;
    }
    
    
    
}