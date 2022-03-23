using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Axi3._0.Models;
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

        public IActionResult Articles()
        {
            var articleViewModel = new ArticleViewModel();
            articleViewModel.GetArticleModels();
            return View(articleViewModel);
        }

        public ArticleViewModel CreateArticles() //todo delete maybe?
        {
            var articleViewModel = new ArticleViewModel();
            //articleViewModel.CreateArticle(name, price, imgRef, category, description);
            return articleViewModel;
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        
    }
}