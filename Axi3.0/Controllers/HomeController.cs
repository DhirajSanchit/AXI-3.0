﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Axi3._0.Models;
using AxiDAL.DTOs;
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
        public readonly ContainerFactory _containerFactory;

        public HomeController(ILogger<HomeController> logger, ITestDapperContainer tdc,
            ContainerFactory ContainerFactory)
        {
            _logger = logger;
            _tdc = tdc;
            _containerFactory = ContainerFactory;
            
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
                ImgRef = model.ImgRef,
                Description = model.Description,
                Category = model.Category
            }));

            return RedirectToAction("AddArticle", "Home");
        }

        [HttpGet]
        public IActionResult AddArticle()
        {
            var articleModel = new ArticleModel();
            articleModel.CategoryEnum = _containerFactory.GetCategoryContainer().GetAllCategories();
            return View(articleModel);
        }

        public IActionResult ScannerDelivery()
        {
            //todo get data for shipment viewmodel
            var model = new ShipmentViewModel();
            var shipment = new ShipmentModel();
            shipment.Id = 1;
            shipment.Name = "Test shipment";
            shipment.Date = DateTime.Now;
            shipment.Processed = false;
            model.ShipmentModels.Add(shipment);
            return View(model);
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
            CategoryModel categoryModel = new();
            categoryModel.Categories = _containerFactory.GetCategoryContainer().GetAllCategories();
            return View(categoryModel);
        }
        
        [HttpPost]
        public IActionResult AddCategory(CategoryModel model)
        {
            _containerFactory.GetCategoryContainer().AddCategory(new CategoryDto()
            {
                Name = model.Category.Name
            });
            return RedirectToAction("Categories", "Home");
        }
        
        [HttpPost]
        public IActionResult DeleteCategory(CategoryModel model)
        {
            _containerFactory.GetCategoryContainer().RemoveCategory(new CategoryDto()
            {
                Name = model.Category.Name,
                Id = model.Category.Id
            });
            return RedirectToAction("Categories", "Home");
        }
        
        [HttpPost]
        public IActionResult UpdateCategory(CategoryModel model)
        {
            _containerFactory.GetCategoryContainer().UpdateCategory(new CategoryDto()
            {
                Name = model.Category.Name,
                Id = model.Category.Id
            });
            return RedirectToAction("Categories", "Home");
        }
        
        
    }
}