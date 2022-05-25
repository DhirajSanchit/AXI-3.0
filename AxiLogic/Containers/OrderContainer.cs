using System;
using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiDAL.Factories;
using AxiDAL.Interfaces;
using AxiLogic.Classes;
using AxiLogic.Interfaces;

namespace AxiLogic.Containers
{
    public class OrderContainer : IOrderContainer
    {
        private List<Order> _orders;
        private IDalFactory _dalFactory;
        
        public IReadOnlyCollection<Order> GetOrder()
        {
            return _orders;
        }

        
        
        public OrderContainer(DalFactory dalFactory)
        {
            _dalFactory = dalFactory;
            _orders = new List<Order>();
        }

        public void ClearOrders()
        {
            _orders.Clear();
        }


        /// <summary>
        /// Loads orders that need to be processed from DB.
        /// </summary>
        public List<OrderDto> GetProcessableOrders()
        {
            var OrderDtos = _dalFactory.GetOrderDal().GetAllUnfinishedOrders();
            List<OrderDto> orders = new();
            foreach (var orderDto in OrderDtos)
            {
                orders.Add(orderDto);
            }

            return orders;
        }
        
        /// <summary>
        /// Loads all orders from DB.
        /// </summary>
        public IList<OrderDto> GetAllUnfinishedOrders()
        {
            //get all orders from DB
            return _dalFactory.GetOrderDal().GetAllUnfinishedOrders();
        }
        
        public void AddOrder(Order order)
        {
            if (_orders.Contains(order))
            {
                throw new ArgumentException("Can not add duplicate order to list");
            }
            _orders.Add(order);
        }

        public void RemoveOrder(Order order)
        {
            if (!_orders.Contains(order))
            {
                throw new ArgumentException("Can not remove non-contained order from list");
            }
            _orders.Remove(order);
        }

        public IList<OrderArticleDto> getOrderArticles(int orderId)
        {
            return _dalFactory.GetOrderArticleDal().GetAllOrderArticlesFromOrder(new OrderDto() {Id = orderId});
        }
        
        public OrderDto GetOrderById(int orderId)
        {
            return _dalFactory.GetOrderDal().GetOrderById(orderId);
        }
        
        public void UpdateOrder(OrderDto orderDto)
        {
            _dalFactory.GetOrderDal().UpdateOrderProgress(orderDto);
            orderDto.OrderArticles.ForEach(x => _dalFactory.GetOrderArticleDal().UpdateOrderArticleProgress(x));
        }
    }
}