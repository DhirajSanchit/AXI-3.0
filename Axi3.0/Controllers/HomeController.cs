using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Axi3._0.Models;
using AxiDAL.DTOs;  
using AxiLogic.Classes;
using AxiLogic.Helpers;
using AxiLogic.Interfaces;

namespace Axi3._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ITestDapperContainer _tdc;

        public readonly ContainerFactory _containerFactory;
        
        public HomeController(ILogger<HomeController> logger, ITestDapperContainer tdc, ContainerFactory ContainerFactory)
        {
            _logger = logger;
            _tdc = tdc;
            _containerFactory = ContainerFactory;
        }

        public IActionResult Index()
        {
            //Keep code below for debug purposes
            TestViewModel tvm = new TestViewModel();
            tvm.tData = _containerFactory.GetTestDapperContainer().GetAll();
            return View(tvm);

             //return View();
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
            //ContainerFactory.ArticleContainer.GetAllArticles();
            articleViewModel.GetArticleModels();
            return View(articleViewModel);
        }
        
        [HttpPost]
        public IActionResult AddArticle(ArticleModel model)
        { 
            _containerFactory.GetArticleContainer().AddArticle(new Article(new ArticleDto()
            {
                Name = model.Name,
                Price = model.Price,
                ImgRef = model.ImgRef,
                Description = model.Description,
                Category = model.Category.ToString()
            }));
            
            return RedirectToAction("AddArticle", "Home");
        }

        [HttpGet]
        public IActionResult AddArticle()
        {
            var articleModel = new ArticleModel();
            return View(articleModel);
        }
        
        public IActionResult ScannerDelivery()
        {
            return View();
        }

        public IActionResult ScannerOrder()
        {
            return View();
        }
        
        // public IActionResult Articles()
        // {
        //     var articleViewModel = new ArticleViewModel();
        //     articleViewModel.GetArticleModels();
        //     return View(articleViewModel);
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
        [HttpPost]
        public IActionResult PlaceArticle(MoveArticleViewModel model)
        {
            model.PlaceArticle();
            return RedirectToAction("PlaceArticle", "Home");            
        }
        [HttpGet]
        public IActionResult PlaceArticle()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult TakeArticle(MoveArticleViewModel model)
        {
            model.TakeArticle();
            return RedirectToAction("PlaceArticle", "Home");
        }

    }
}