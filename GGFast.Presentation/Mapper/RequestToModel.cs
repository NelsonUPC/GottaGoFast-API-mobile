using AutoMapper;
using GottaGoFast.Domain.Publishing.Models.Commands;
using GottaGoFast.Domain.Publishing.Models.Entities;
using GottaGoFast.Domain.Security.Models.Commands;

namespace GottaGoFast.Presentation.Mapper;

public class RequestToModel : Profile
{
    public RequestToModel()
    {
        CreateMap<SignUpCommand, User>();
        CreateMap<UpdateUserCommand, User>();
        CreateMap<CreateRentCommand, Rent>();
        CreateMap<UpdateRentCommand, Rent>();
        CreateMap<DeleteRentCommand, Rent>();
    }
}