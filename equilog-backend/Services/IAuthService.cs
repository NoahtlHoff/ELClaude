using equilog_backend.Auth;
using equilog_backend.Models;

namespace equilog_backend.Interfaces;

public interface IAuthService
{
    string GenerateToken(User user);
    bool ValidateToken(string token);
    User? GetUserFromToken(string token);
}