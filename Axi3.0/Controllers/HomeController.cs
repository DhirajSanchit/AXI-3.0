using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Axi3._0.Models;
using Axi3._0.Models.Statistics;
using AxiDAL.DTOs;
using AxiDAL.DTOs.Statistics;
using AxiDAL.Interfaces;
using AxiLogic.Classes;
using AxiLogic.Factories;
using AxiLogic.Helpers;
using AxiLogic.Interfaces;

namespace Axi3._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ITestDapperContainer _tdc;
        private readonly ContainerFactory _containerFactory;

        public HomeController(ILogger<HomeController> logger, ITestDapperContainer tdc,
            ContainerFactory containerFactory)
        {
            _logger = logger;
            _tdc = tdc;
            _containerFactory = containerFactory;
            
        }

        public IActionResult Index()
        {
            //Keep code below for debug purposes
            //TestViewModel tvm = new TestViewModel();
            //tvm.tData = _containerFactory.GetTestDapperContainer().GetAll();
            //return View(tvm);
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
            var categories = _containerFactory.GetCategoryContainer().GetAllCategories();
            foreach (var row in stockModel.StockRows)
            {
                foreach (var categoryDto in categories)
                {
                    if (categoryDto.Id.ToString() == row.Category)
                    {
                        row.Category = categoryDto.Name;
                    }
                }
            }
            return View(stockModel);
        }

        public IActionResult TotalStock()
        {
            var totalStockViewModel = new TotalStockViewModel();
            totalStockViewModel.StockModels = _containerFactory.GetStockContainer().GetAllStocks();
            return View(totalStockViewModel);
        }

        public IActionResult Articles()
        {
            var articleViewModel = new ArticleViewModel();
            articleViewModel.ArticleModels = _containerFactory.GetArticleContainer().GetAllArticles();
            // articleViewModel.GetArticleModels(); //TODO < Should be from factory, not from articleViewModel
            return View(articleViewModel);
        }

        [HttpPost]
        public IActionResult AddArticle(ArticleModel model)
        {
            _containerFactory.GetArticleContainer().AddArticle(new Article(new ArticleDto()
            {
                Name = model.Name,
                Price = model.Price,
                Img = model.ImgRef,
                Description = model.Description,
                CategoryName = model.CategoryName,
                Id = Int32.Parse(model.CategoryName)
            }));

            return RedirectToAction("AddArticle", "Home");
        }

        [HttpGet]
        public IActionResult AddArticle()
        {
            var articleModel = new ArticleModel
            {
                CategoryEnum = _containerFactory.GetCategoryContainer().GetAllCategories()
            };
            return View(articleModel);
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
            model.locationstring = model.RowName + "." + model.RackLocation + "." + model.PlankLocation + "." +
                                   model.PalletLocation;
            model.PlaceArticle();
            return RedirectToAction("PlaceArticle", "Home");
        }

        [HttpGet]
        public IActionResult PlaceArticle()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult TakeArticle()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult TakeArticle(MoveArticleViewModel model)
        {
            model.locationstring = model.RowName + "." + model.RackLocation + "." + model.PlankLocation + "." +
                                   model.PalletLocation;
            model.TakeArticle();
            return RedirectToAction("TakeArticle", "Home");
        }

        [HttpGet]
        public IActionResult Categories()
        {
            CategoryModel categoryModel = new()
            {
                Categories = _containerFactory.GetCategoryContainer().GetAllCategories()
            };
            return View(categoryModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(string categoryName)
        {
            _containerFactory.GetCategoryContainer().AddCategory(new CategoryDto()
            {
                Name = categoryName
            });
            return RedirectToAction("Categories", "Home");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(CategoryModel model)
        {
            _containerFactory.GetArticleContainer().removeCategoryFromArticles(model.CategoryId);
            _containerFactory.GetCategoryContainer().RemoveCategory(new CategoryDto()
            {
                Id = model.CategoryId //todo validate this
            });
            return RedirectToAction("Categories", "Home");
        }

        [HttpGet]
        public IActionResult UpdateArticle(int id)
        {
            var article = _containerFactory.GetArticleContainer().GetArticleById(id);
            var CategoryDtos = _containerFactory.GetCategoryContainer().GetAllCategories();
            var articleModel = new ArticleModel()
            {
                Price = article.Price,
                Barcode = article.Barcode,
                ImgRef = article.Img,
                Name = article.Name,
                Description = article.Description,
                Id = article.Id,
                CategoryName = article.CategoryName,
                CategoryId = article.CategoryId,
                Disabled = article.Disabled,
                CategoryEnum = CategoryDtos
            };
            return View(articleModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateArticle(ArticleModel model)
        {
            _containerFactory.GetArticleContainer().UpdateArticle(new Article(new ArticleDto()
            {
                Name = model.Name,
                // Barcode = model.Barcode,
                // CategoryName = model.CategoryName,
                // CategoryId = model.CategoryId,
                Description = model.Description,
                Disabled = model.Disabled,
                Id = model.Id,
                Img = model.ImgRef,
                Price = model.Price
            }));
            return RedirectToAction("Articles", "Home");
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCategory(CategoryModel model)
        {
            _containerFactory.GetCategoryContainer().UpdateCategory(new CategoryDto()
            {
                Name = model.CategoryName,
                Id = model.CategoryId
            });
            return RedirectToAction("Categories", "Home");
        }
        
        [HttpGet]
        public IActionResult Statistics()
        {
            var model = new StatModel();
            var (categoryAmounts, ordersPerMonth, popularProducts, productiveEmployee) 
                = _containerFactory.GetStatContainer().GetStatistics();

            foreach (var amountInCategoryDto in categoryAmounts)
            {
                model.CategoryAmounts.Add(new CategoryAmount()
                {
                    Amount = amountInCategoryDto.Amount,
                    CategoryName = amountInCategoryDto.CategoryName
                });
            }
            foreach (var order in ordersPerMonth)
            {
                model.OrdersPerMonth.Add(new OrdersPerMonth()
                {
                    Month = order.Month,
                    Orders = order.Amount
                });
            }
            foreach (var product in popularProducts)
            {
                model.PopularProduct.Add(new PopularProduct()
                {
                    Name = product.Name,
                    Total = product.Total
                });
            }
            foreach (var employee in productiveEmployee)
            {
                model.ProductiveEmployees.Add(new ProductiveEmployee()
                {
                    Name = employee.Name,
                    TotalProcessed = employee.Total
                });
            }
            return View(model);
        }
    }
}