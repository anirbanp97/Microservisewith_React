using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Infrastructure.DbHelpers
{
    public static class SqlHelper
    {
        public static SqlCommand CreateStoredProcedure(this SqlConnection conn, string procName)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = procName;
            return cmd;
        }
    }
}
