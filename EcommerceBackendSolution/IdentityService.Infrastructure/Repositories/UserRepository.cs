using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Infrastructure.Repositories
{
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<bool> RegisterUserAsync(string username, string passwordHash)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_RegisterUser", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

            await conn.OpenAsync();
            var rows = await cmd.ExecuteNonQueryAsync();
            return rows > 0;
        }

        public async Task<string?> ValidateLoginAsync(string username, string passwordHash)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_ValidateUser", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

            await conn.OpenAsync();
            var result = await cmd.ExecuteScalarAsync();
            return result?.ToString();
        }
    }
}
