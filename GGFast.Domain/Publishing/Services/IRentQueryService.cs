using GottaGoFast.Domain.Publishing.Models.Queries;
using GottaGoFast.Domain.Publishing.Models.Response;

namespace GottaGoFast.Domain.Publishing.Services;

public interface IRentQueryService
{
    Task<List<RentResponse>?> Handle(GetAllRentsQuery query);
    Task<RentResponse?> Handle(GetRentByIdQuery query);
}