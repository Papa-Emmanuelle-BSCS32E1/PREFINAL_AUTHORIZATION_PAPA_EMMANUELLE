using System.Collections.Concurrent;
using System.Threading.Tasks;
using AuthServer.Core.Models;
using AuthServer.Core.Services;
using BCrypt.Net;

namespace AuthServer.Services
{
    public class UserService : IUserService
    {
        private readonly ConcurrentDictionary<string, User> _users = new ConcurrentDictionary<string, User>();

        public Task<User> RegisterAsync(string username, string password)
        {
            if (_users.ContainsKey(username))
                return Task.FromResult<User>(null);

            var user = new User
            {
                Username = username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
            };

            _users[username] = user;
            return Task.FromResult(user);
        }

        public Task<User> LoginAsync(string username, string password)
        {
            if (_users.TryGetValue(username, out var user) && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return Task.FromResult(user);
            }

            return Task.FromResult<User>(null);
        }
    }
}
