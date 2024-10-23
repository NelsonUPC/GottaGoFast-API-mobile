using GottaGoFast.Domain.Security.Services;

namespace GottaGoFast.Application.Security.CommandServices;

public class EncryptService : IEncryptService
{
    public string Encrypt(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
    
    public bool VerifyPassword(string password, string passwordhash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordhash);
    }
}