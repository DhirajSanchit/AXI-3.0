using System.Diagnostics;
using Axi3._0.Models;
using AxiLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Axi3._0.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IArticleContainer _tdc;
        
        public ArticlesController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //_tdc = tdc;
        }

        public IActionResult Articles()
        {
            var articleViewModel = new ArticleViewModel();
            articleViewModel.GetArticleModels();
            //return View(articleViewModel);
            return null;
        }
        
        [HttpGet]
        public IActionResult AddArticle()
        {
            return View();
        }
        
        public IActionResult ScannerIndex()
        {
            return View();
        }

        public IActionResult PlaceArticle()
        {
            return View();
        }
        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
        [HttpPost]
        public IActionResult PlaceArticle(MoveArticleViewModel moveArticleViewModel)
        {

            return View();
        }
        
        [HttpPost]
        public IActionResult TakeArticle(MoveArticleViewModel moveArticleViewModel)
        {
            return null;
        }
        
    }
}