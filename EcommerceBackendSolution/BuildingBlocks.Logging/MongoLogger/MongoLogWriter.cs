using BuildingBlocks.Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
namespace BuildingBlocks.Logging.MongoLogger
{
    public class MongoLogWriter : ILogWriter
    {
        private readonly IMongoCollection<BsonDocument> _collection;

        public MongoLogWriter(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("MongoDbLogging") ?? "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ECommerce_LoggingDB");
            _collection = database.GetCollection<BsonDocument>("Logs");
        }

        public async Task LogAsync(string message, string level = "Information")
        {
            var log = new BsonDocument
            {
                { "Message", message },
                { "Level", level },
                { "Timestamp", DateTime.UtcNow }
            };

            await _collection.InsertOneAsync(log);
        }
    }
}
