using System.Threading.Tasks;
using AuthServer.Core.Models;

namespace AuthServer.Core.Services
{
    public interface IUserService
    {
        Task<User> RegisterAsync(string username, string password);
        Task<User> LoginAsync(string username, string password);
    }
}
