using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.DbHelpers
{
    public static class SqlHelper
    {
        public static SqlConnection GetConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
