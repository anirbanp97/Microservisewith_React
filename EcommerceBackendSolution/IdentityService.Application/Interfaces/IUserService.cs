using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(string username, string password);
        Task<string?> LoginAsync(string username, string password);
    }
}
