using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiLogic.Classes;

namespace AxiLogic.Interfaces
{
    public interface IOrderContainer
    {
        public IReadOnlyCollection<Order> GetOrder();
        public void ClearOrders();
        public List<OrderDto> GetProcessableOrders();
        public IList<OrderDto> GetAllUnfinishedOrders();
        public void AddOrder(Order order);
        public void RemoveOrder(Order order);
        public IList<OrderArticleDto> getOrderArticles(int orderId);
        public OrderDto GetOrderById(int orderId);
        public void UpdateOrder(OrderDto orderDto);
    }
}