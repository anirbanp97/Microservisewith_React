using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotService.Infrastructure.Models
{
    public class ChatHistory
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; } = string.Empty;

        [BsonElement("query")]
        public string Query { get; set; } = string.Empty;

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
