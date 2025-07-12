using LoggingService.Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingService.Infrastructure.MongoContext
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration config)
        {
            var client = new MongoClient(config["MongoSettings:ConnectionString"]);
            _database = client.GetDatabase(config["MongoSettings:Database"]);
        }

        public IMongoCollection<LogEntry> Logs => _database.GetCollection<LogEntry>("Logs");
    }
}
