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
        public Category Category;

        public Article()
        {
        }

        public Article(string name, double price)
        {
            Name = name;
            Price = price;
        }
        
        public Article(string name, double price, string barcode, string imgRef, string description,  int id, Category category)
        {
            Name = name;
            Price = price;
            Barcode = barcode;
            ImgRef = imgRef;
            Description = description;
            Id = id;
            Category = category;
        }
        
        public Article(ArticleDto articleDto)
        {
            Name = articleDto.Name;
            Price = articleDto.Price;
            ImgRef = articleDto.ImgRef;
            Category = Enum.Parse<Category>(articleDto.Category);  
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
                Barcode = Barcode,
                Category = Category.ToString()
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