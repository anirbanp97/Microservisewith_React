using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Common.Helpers
{
    public static class DateTimeHelper
    {
        public static string ToUtcIso(this DateTime date)
        {
            return date.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
        }
    }
}
