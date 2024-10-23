using AutoMapper;
using GottaGoFast.Domain.Publishing.Models.Commands;
using GottaGoFast.Domain.Publishing.Models.Entities;
using GottaGoFast.Domain.Security.Models.Commands;

namespace GottaGoFast.Presentation.Mapper;

public class ModelToRequest : Profile
{
    public ModelToRequest()
    {
        CreateMap<User, SignUpCommand>();
        CreateMap<User, UpdateUserCommand>();
        CreateMap<Rent, CreateRentCommand>();
        CreateMap<Rent, UpdateRentCommand>();
        CreateMap<Rent, DeleteRentCommand>();
    }
}