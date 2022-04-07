using Axi3._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Axi3._0.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // private ITestDapperContainer _tdc;
        
        public ArticlesController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //_tdc = tdc;
        }

        public IActionResult Articles()
        {
            var articleViewModel = new ArticleViewModel();
            articleViewModel.GetArticleModels();
            return View(articleViewModel);
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
        
    }
}