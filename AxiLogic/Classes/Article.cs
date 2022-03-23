﻿using AxiInterfaces.DTOs;

namespace AxiLogic.Classes
{ 

    public class Article
    {
        public double Price { get; private set; }
        public string Barcode { get; private set; }
        public string ImgRef { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Id { get; private set; }
        public Category Category { get; private set; }

        public Article(string name, double price)
        {
            Name = name;
            Price = price;
        }
        
        
        public void SetName(string name)
        {
            Name = name;
        }
        
        public void SetDescription(string description)
        {
            Description = description;
        }

        public void SetCategory(Category category)
        {
            Category = category;
        }
        
        public void SetBarcode(string barcode)
        {
            Barcode = barcode;
        }
        
        public void SetImg(string img)
        {
            ImgRef = img;
        }
        
        public void SetPrice(double price)
        {
            Price = price;
        }

        public ArticleDto ToDto()
        {
            return new ArticleDto
            {
                Name = Name,
                Id = Id,
                Description = Description,
                ImgRef = ImgRef,
                Price = Price,
                Barcode = Barcode
            };
        }
    }
    
    public enum Category
    {
        Electronics,
        Cosmetics,
        Tools
    }
    
}