using OrderService.Application.Interfaces;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> GetAllAsync() => await _orderRepository.GetAllAsync();
        public async Task<Order?> GetByIdAsync(int id) => await _orderRepository.GetByIdAsync(id);
        public async Task AddAsync(Order order) => await _orderRepository.AddAsync(order);
        public async Task UpdateAsync(Order order) => await _orderRepository.UpdateAsync(order);
        public async Task DeleteAsync(int id) => await _orderRepository.DeleteAsync(id);
    }
}
