using GottaGoFast.Domain.Publishing.Models.Entities;

namespace GottaGoFast.Domain.Security.Services;

public interface ITokenService
{
    string GenerateToken(User user, int id);
    Task<int?> ValidateToken(string token);
}