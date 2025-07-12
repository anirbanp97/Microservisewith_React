using ChatBotService.Infrastructure.Interfaces;
using ChatBotService.Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotService.Infrastructure.Services
{
    public class ChatService : IChatService
    {
        private readonly IMongoCollection<ChatHistory> _collection;

        public ChatService(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            var database = client.GetDatabase("ChatBotDB");
            _collection = database.GetCollection<ChatHistory>("UserChats");
        }

        public async Task SaveUserQueryAsync(string userId, string query)
        {
            var entry = new ChatHistory { UserId = userId, Query = query };
            await _collection.InsertOneAsync(entry);
        }

        public async Task<List<string>> GetUserHistoryAsync(string userId)
        {
            var history = await _collection.Find(c => c.UserId == userId)
                                            .SortByDescending(c => c.Timestamp)
                                            .Limit(10)
                                            .ToListAsync();
            return history.Select(x => x.Query).ToList();
        }
    }
}
