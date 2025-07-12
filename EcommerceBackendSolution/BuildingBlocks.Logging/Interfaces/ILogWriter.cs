using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Logging.Interfaces
{
    public interface ILogWriter
    {
        Task LogAsync(string message, string level = "Information");
    }
}
