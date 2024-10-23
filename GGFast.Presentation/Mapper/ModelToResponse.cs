using AutoMapper;
using GottaGoFast.Domain.Publishing.Models.Entities;
using GottaGoFast.Domain.Publishing.Models.Response;

namespace GottaGoFast.Presentation.Mapper;

public class ModelToResponse : Profile
{
    public ModelToResponse()
    {
        CreateMap<User, UserResponse>();
        CreateMap<Rent, RentResponse>();
    }
}