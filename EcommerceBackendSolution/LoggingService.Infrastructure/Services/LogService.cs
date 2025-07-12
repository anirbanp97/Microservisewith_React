using LoggingService.Infrastructure.MongoContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingService.Infrastructure.Services
{
    public class LogService
    {
        private readonly MongoDbContext _context;

        public LogService(MongoDbContext context)
        {
            _context = context;
        }

        public async Task AddLogAsync(LogEntry entry)
        {
            await _context.Logs.InsertOneAsync(entry);
        }
    }
}
