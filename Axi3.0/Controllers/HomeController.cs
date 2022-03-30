using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Axi3._0.Models;
using AxiLogic.Containers;
using AxiLogic.Interfaces;

namespace Axi3._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ITestDapperContainer _tdc;
        
        public HomeController(ILogger<HomeController> logger, ITestDapperContainer tdc)
        {
            _logger = logger;
            _tdc = tdc;
        }

        public IActionResult Index()
        {
            TestViewModel tvm = new TestViewModel();
             _tdc.dt = _tdc.GetAll();
             tvm.tData = _tdc.dt;
            return View(tvm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Stock()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}