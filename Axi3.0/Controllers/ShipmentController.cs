using Axi3._0.Models;
using AxiLogic.Containers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult Shipments()
        {
            var shipmentViewModel = new ShipmentViewModel();
            shipmentViewModel.
        }
    }
}
