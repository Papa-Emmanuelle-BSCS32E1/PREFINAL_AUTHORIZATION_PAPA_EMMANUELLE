using AuthServer.Core.Models;


namespace AuthServer.Core.Services
{
    public interface IAuthService
    {
        string GenerateToken(User user);
    }
}
