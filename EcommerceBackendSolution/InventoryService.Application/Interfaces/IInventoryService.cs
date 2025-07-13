using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Application.Interfaces
{
    public interface IInventoryService
    {
        Task<List<InventoryItem>> GetAllAsync();
        Task<InventoryItem?> GetByIdAsync(int id);
        Task AddAsync(InventoryItem item);
        Task UpdateAsync(InventoryItem item);
        Task DeleteAsync(int id);
    }
}
