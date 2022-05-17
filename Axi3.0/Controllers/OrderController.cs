using System.Collections.Generic;
using System.Linq;
using Axi3._0.Models;
using AxiDAL.DTOs;
using AxiLogic.Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Axi3._0.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly ContainerFactory _containerFactory;
        
        public OrderController(ILogger<OrderController> logger,
            ContainerFactory containerFactory)
        {
            _logger = logger;
            _containerFactory = containerFactory;
        }

        // public IActionResult Orders()
        // {
        //     var orderViewModel = new OrderViewModel();
        //     orderViewModel.
        // }
        public IActionResult ScannerOrder()
        {
            var orders =_containerFactory.GetOrderContainer().GetAllUnfinishedOrders();
            var model = new OrderViewModel();
            foreach (var orderDto in orders)
            {
                model.OrderModels.Add(new OrderModel()
                {
                    Id = orderDto.Id,
                    Name = orderDto.Name,
                    Date = orderDto.Date,
                    Processed = orderDto.Processed,
                    InvoiceId = orderDto.InvoiceId
                });
            }
            return View(model);
        }
        
        public string GetOrderArticles(int orderId)
        {
            //todo fix factory pattern
            var articles = _containerFactory.GetOrderContainer().getOrderArticles(orderId);
            var order = _containerFactory.GetOrderContainer().GetOrderById(orderId);
            var dtoList = new List<OrderArticleDto>();
            foreach (var orderArticleDto in articles)
            {
               var article = _containerFactory.GetArticleContainer().GetArticleById(orderArticleDto.ArticleId);
                
                dtoList.Add(new OrderArticleDto()
                {
                    Amount = orderArticleDto.Amount,
                    Article = article,
                    ArticleId = article.Id,
                    ScannedAmount = orderArticleDto.ScannedAmount,
                    OrderId = order.Id
                });
            }
            var jsonObj = new JObject();
            jsonObj["orderArticles"] = JToken.FromObject(dtoList);
            jsonObj["order"] = JToken.FromObject(order);
            return jsonObj.ToString();
        }

        public void PostOrderProcess(string orderArticles, bool processed)
        {
            var jObject = JObject.Parse(orderArticles);
            var orderDto = new OrderDto();
            orderDto.OrderArticles = new List<OrderArticleDto>();
            foreach (var obj in jObject["orderArticles"])
            {
                orderDto.OrderArticles.Add(new OrderArticleDto()
                {
                    Amount = (int)obj["Amount"],
                    ArticleId = (int)obj["ArticleId"],
                    ScannedAmount = (int)obj["ScannedAmount"],
                    OrderId = (int)obj["OrderId"]
                });
            }
            orderDto.Processed = processed;
            orderDto.Id = jObject["orderArticles"].First()["OrderId"].Value<int>();    
            _containerFactory.GetOrderContainer().UpdateOrder(orderDto);
        }
    }
}
