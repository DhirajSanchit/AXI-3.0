using Axi3._0.Models;
using AxiLogic.Containers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AxiDAL.DTOs;
using AxiLogic.Factories;
using Newtonsoft.Json.Linq;

namespace Axi3._0.Controllers
{
    public class ShipmentController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly ContainerFactory _containerFactory;
        public ShipmentController(ILogger<HomeController> logger,
            ContainerFactory containerFactory)
        {
            _logger = logger;
            _containerFactory = containerFactory;
        }

        // public IActionResult Shipments()
        // {
        //     var shipmentViewModel = new ShipmentViewModel();
        //     shipmentViewModel.
        // }
        
        public string GetShipmentArticles(int shipmentId)
        {
            //todo fix factory pattern
            var articles = _containerFactory.GetShipmentContainer().getShipmentArticles(shipmentId);
            var shipment = _containerFactory.GetShipmentContainer().GetShipmentById(shipmentId);
            var dtoList = new List<ShipmentArticleDto>();
            foreach (var shipmentArticleDto in articles)
            {
               var article = _containerFactory.GetArticleContainer().GetArticleById(shipmentArticleDto.ArticleId);
                
                dtoList.Add(new ShipmentArticleDto()
                {
                    Amount = shipmentArticleDto.Amount,
                    Article = article,
                    ArticleId = article.Id,
                    ScannedAmount = shipmentArticleDto.ScannedAmount,
                    ShipmentId = shipment.Id
                });
            }
            var jsonObj = new JObject();
            jsonObj["shipmentArticles"] = JToken.FromObject(dtoList);
            jsonObj["shipment"] = JToken.FromObject(shipment);
            return jsonObj.ToString();
        }

        public void PostShipmentProcess(string shipmentArticles, bool processed)
        {
            var jObject = JObject.Parse(shipmentArticles);
            var shipmentDto = new ShipmentDto();
            shipmentDto.ShipmentArticles = new List<ShipmentArticleDto>();
            foreach (var obj in jObject["shipmentArticles"])
            {
                shipmentDto.ShipmentArticles.Add(new ShipmentArticleDto()
                {
                    Amount = (int)obj["Amount"],
                    ArticleId = (int)obj["ArticleId"],
                    ScannedAmount = (int)obj["ScannedAmount"],
                    ShipmentId = (int)obj["ShipmentId"]
                });
            }
            shipmentDto.Processed = processed;
            shipmentDto.Id = jObject["shipmentArticles"].First()["ShipmentId"].Value<int>();    
            _containerFactory.GetShipmentContainer().UpdateShipment(shipmentDto);
        }
    }
}
