using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Axi3._0.Models;
using AxiInterfaces.DTOs;
using AxiLogic.Classes;
using AxiLogic.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Axi3._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Stock()
        {
            var stockModel = new StockModel();
            stockModel.GetStockRows();
            return View(stockModel);
        }
        
        [HttpPost]
        public IActionResult AddArticle(ArticleModel model)
        {
            Toolbox.ArticleContainer.AddArticle(new Article(new ArticleDto()
            {
                Name = model.Name,
                Price = model.Price,
                ImgRef = model.ImgRef,
                Description = model.Description,
                Category = model.Category.ToString()
            }));

            return RedirectToAction("AddArticle");
        }

        [HttpGet]
        public IActionResult AddArticle()
        {
            return View();
        }

       
        public IActionResult Articles()
        {
            var articleViewModel = new ArticleViewModel();
            articleViewModel.GetArticleModels();
            return View(articleViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        
    }
}