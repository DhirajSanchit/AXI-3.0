using System;
using AxiDAL.DTOs;

namespace AxiLogic.Classes
{ 

    public class Article
    {
        public double Price;
        public string Barcode;
        public string ImgRef;
        public string Name;
        public string Description;
        public int Id;
        public string Category;

        public Article(string name, double price)
        {
            Name = name;
            Price = price;
        }
        
        public Article(string name, double price, string barcode, string imgRef, string description, string category)
        {
            Name = name;
            Price = price;
            Barcode = barcode;
            ImgRef = imgRef;
            Description = description;
            Category = category;
        }
        
        public Article(ArticleDto articleDto)
        {
            Id = articleDto.Id;
            Name = articleDto.Name;
            Barcode = articleDto.Barcode;
            Price = articleDto.Price;
            ImgRef = articleDto.ImgRef;
            Category = articleDto.Category;
            Description = articleDto.Description;
        }
        
        public void SetName(string name)
        {
            Name = name;
        }
        
        public void SetDescription(string description)
        {
            Description = description;
        }

        public void SetCategory(string category)
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
                Barcode = Barcode,
                Category = Category
            };
        }
    }
}