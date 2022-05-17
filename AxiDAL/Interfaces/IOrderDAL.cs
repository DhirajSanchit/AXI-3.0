using System.Collections.Generic;
using AxiDAL.DTOs;

namespace AxiDAL.Interfaces
{
    public interface IOrderDAL
    {
        public IList<OrderDto> GetAll();
        public IList<OrderDto> GetAllUnfinishedOrders();
        public int AddOrder(OrderDto orderDto);
        public void RemoveOrder(OrderDto orderDto);
        public void UpdateOrder(OrderDto orderDto);
        public OrderDto GetOrderById(int id);
        public void UpdateOrderProgress(OrderDto orderDto);
    }
}