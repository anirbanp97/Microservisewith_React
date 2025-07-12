using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotService.Infrastructure.Interfaces
{
    public interface IChatService
    {
        Task SaveUserQueryAsync(string userId, string query);
        Task<List<string>> GetUserHistoryAsync(string userId);
    }
}
