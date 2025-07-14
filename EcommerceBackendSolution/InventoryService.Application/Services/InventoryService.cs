using InventoryService.Application.Interfaces;
using InventoryService.Domain.Entities;
using InventoryService.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Application.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly InventoryRepository _inventoryRepository;

        public InventoryService(InventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<List<InventoryItem>> GetAllAsync()
        {
            return await _inventoryRepository.GetAllAsync();
        }

        public async Task<InventoryItem?> GetByIdAsync(int id)
        {
            return await _inventoryRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(InventoryItem item)
        {
            await _inventoryRepository.AddAsync(item);
        }

        public async Task UpdateAsync(InventoryItem item)
        {
            await _inventoryRepository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            await _inventoryRepository.DeleteAsync(id);
        }
    }
}
