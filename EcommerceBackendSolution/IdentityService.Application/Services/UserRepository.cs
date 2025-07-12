using IdentityService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _repo;

        public UserService(UserRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> RegisterAsync(string username, string password)
        {
            var hash = HashPassword(password);
            return await _repo.RegisterUserAsync(username, hash);
        }

        public async Task<string?> LoginAsync(string username, string password)
        {
            var hash = HashPassword(password);
            return await _repo.ValidateLoginAsync(username, hash);
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
