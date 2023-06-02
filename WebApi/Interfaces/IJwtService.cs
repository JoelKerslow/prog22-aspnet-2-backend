using System.Security.Claims;

namespace WebApi.Interfaces
{
    public interface IJwtService
    {
        string Generate(ClaimsIdentity claimsIdentity, DateTime expiresAt);
        string GetIdFromToken(string token);
    }
}