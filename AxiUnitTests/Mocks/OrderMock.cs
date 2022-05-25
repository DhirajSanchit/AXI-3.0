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
            var orderDto1 = new OrderDto()
            {
                Date = new DateTime(14, 12, 2001),
                Name = "TestName1",
                Id = 1,
                InvoiceId = 1,
                Processed = false
            };
            orderDto1.OrderArticles = (List<OrderArticleDto>) _mockFactory.GetOrderArticleDal().GetAllOrderArticlesFromOrder(orderDto1);
            _OrderDtos.Add(orderDto1);
            
            var orderDto2 = new OrderDto()
            {
                Date = new DateTime(14, 12, 2002),
                Name = "TestName2",
                Id = 2,
                InvoiceId = 2,
                Processed = true
            };
            orderDto2.OrderArticles = (List<OrderArticleDto>) _mockFactory.GetOrderArticleDal().GetAllOrderArticlesFromOrder(orderDto2);
            _OrderDtos.Add(orderDto2);
        }
        
        
        public IList<OrderDto> GetAll()
        {
            return _OrderDtos;
        }

        public IList<OrderDto> GetAllUnfinishedOrders()
        {
            List<OrderDto> returnList = new();
            foreach (var dto in _OrderDtos)
            {
                if (dto.Processed == false)
                {
                    returnList.Add(dto);
                }
            }

            return returnList;
        }

        //todo maybe void this?
        public int AddOrder(OrderDto orderDto)
        {
            var id = 0;
            id = orderDto.Id;
            _OrderDtos.Add(orderDto);
            return id;
        }

        public void RemoveOrder(OrderDto orderDto)
        {
            _OrderDtos.Remove(orderDto);
        }

        public void UpdateOrder(OrderDto orderDto)
        {
            var thisDto = new OrderDto();
            for (var i = 0; i < _OrderDtos.Count; i++)
            {
                if (_OrderDtos[i].Id == orderDto.Id)
                {
                    thisDto = _OrderDtos[i];
                    _OrderDtos.Remove(_OrderDtos[i]);
                }
            }
            _OrderDtos.Add(thisDto);
        }

        public OrderDto GetOrderById(int id)
        {
            var returnDto = new OrderDto();
            foreach (var dto in _OrderDtos)
            {
                if (dto.Id == id)
                {
                    returnDto = dto;
                }
            }

            return returnDto;
        }

        public void UpdateOrderProgress(OrderDto orderDto)
        {
            for (var i = 0; i < _OrderDtos.Count; i++)
            {
                if (orderDto.Id == _OrderDtos[i].Id)
                {
                    _OrderDtos[i].Processed = orderDto.Processed;
                    break;
                }
            }
            
        }
    }
}