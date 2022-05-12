using Axi3._0.Models;
using AxiLogic.Containers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AxiDAL.DTOs;
using Newtonsoft.Json.Linq;

namespace Axi3._0.Controllers
{
    public class ShipmentController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ShipmentContainer _container;

        public ShipmentController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //_tdc = tdc;
        }

        // public IActionResult Shipments()
        // {
        //     var shipmentViewModel = new ShipmentViewModel();
        //     shipmentViewModel.
        // }
        
        public string GetShipmentArticles(int shipmentId)
        {
            //todo get actual shipment articles
            var dto1 = new ShipmentArticleDto()
            {
                Amount = 3,
                Article = new ArticleDto()
                {
                    Id = 1,
                    Name = "Article 1",
                    Price = 10,
                    Barcode = "123",
                    ImgRef = "/images/vector-Search.png",
                    Category = "Test",
                    Description = "Test"
                },
                ScannedAmount = 1,
                ShipmentId = shipmentId
            };
            
            var dto2 = new ShipmentArticleDto()
            {
                Amount = 6,
                Article = new ArticleDto()
                {
                    Id = 2,
                    Name = "Article 2",
                    Price = 20,
                    Barcode = "456",
                    ImgRef = "/images/vector-Search.png",
                    Category = "Test",
                    Description = "Test"
                },
                ScannedAmount = 2,
                ShipmentId = shipmentId
            };

            //todo get actual shipment data
            var shipment = new ShipmentDto();
            shipment.Id = shipmentId;
            shipment.Name = "Shipment 1";
            shipment.Date = DateTime.Now;
            shipment.Processed = false;
            var dtoList = new List<ShipmentArticleDto>();
            dtoList.Add(dto1);
            dtoList.Add(dto2);
            var jsonObj = new JObject();
            jsonObj["shipmentArticles"] = JToken.FromObject(dtoList);
            jsonObj["shipment"] = JToken.FromObject(shipment);
            return jsonObj.ToString();
        }
    }
}
