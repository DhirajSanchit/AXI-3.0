using System;
using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiDAL.Factories;
using AxiDAL.Interfaces;
using AxiLogic.Classes;

namespace AxiUnitTests.Scrubs
{
    public class OrderMock : IOrderDAL
    {

        public List<OrderDto> _OrderDtos = new();
        private IDalFactory _mockFactory;
        public OrderMock(IDalFactory mockFactory)
        {
            _mockFactory = mockFactory;
            _OrderDtos.Add(new OrderDto()
            {
                Date = new DateTime(14,12,2001),
                Name = "TestName1",
                Id = 1,
                InvoiceId = 1,
                OrderArticles = _mockFactory.GetOrderArticleDal().GetAllOrderArticlesFromOrder();
            });
        }
        
        
        public IList<OrderDto> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IList<OrderDto> GetAllUnfinishedOrders()
        {
            throw new System.NotImplementedException();
        }

        public int AddOrder(OrderDto orderDto)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveOrder(OrderDto orderDto)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateOrder(OrderDto orderDto)
        {
            throw new System.NotImplementedException();
        }

        public OrderDto GetOrderById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateOrderProgress(OrderDto orderDto)
        {
            throw new System.NotImplementedException();
        }
    }
}