using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var products = new List<Product>();

            using var conn = SqlHelper.GetConnection(_connectionString);
            using var cmd = new SqlCommand("usp_GetAllProducts", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            await conn.OpenAsync();

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                products.Add(new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Price = Convert.ToDecimal(reader["Price"]),
                    Category = reader["Category"].ToString()
                });
            }

            return products;
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            using var conn = SqlHelper.GetConnection(_connectionString);
            using var cmd = new SqlCommand("usp_GetProductById", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Id", id);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Price = Convert.ToDecimal(reader["Price"]),
                    Category = reader["Category"].ToString()
                };
            }

            return null;
        }

        public async Task AddAsync(Product product)
        {
            using var conn = SqlHelper.GetConnection(_connectionString);
            using var cmd = new SqlCommand("usp_AddProduct", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@Category", product.Category);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            using var conn = SqlHelper.GetConnection(_connectionString);
            using var cmd = new SqlCommand("usp_UpdateProduct", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Id", product.Id);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@Category", product.Category);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var conn = SqlHelper.GetConnection(_connectionString);
            using var cmd = new SqlCommand("usp_DeleteProduct", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Id", id);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
