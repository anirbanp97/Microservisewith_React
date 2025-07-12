using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BuildingBlocks.Common.Helpers
{
    public static class SlugHelper
    {
        public static string GenerateSlug(string phrase)
        {
            string str = phrase.ToLowerInvariant();
            str = Regex.Replace(str, "[^a-z0-9\s-]", "");
            str = Regex.Replace(str, "\s+", " ").Trim();
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, "\s", "-");
            return str;
        }
    }
}
