using GottaGoFast.Domain.Publishing.Models.Queries;
using GottaGoFast.Domain.Publishing.Models.Response;

namespace GottaGoFast.Domain.Publishing.Services;

public interface IUserQueryService
{
    Task<List<UserResponse>?> Handle(GetAllUsersQuery query);
    Task<UserResponse?> Handle(GetUserByIdQuery query);
}