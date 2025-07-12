using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingService.Infrastructure.Models
{
    public class LogEntry
    {
        public string Id { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string Level { get; set; } = "Information";
        public string Message { get; set; } = string.Empty;
        public string? Service { get; set; }
        public string? Exception { get; set; }
    }
}
