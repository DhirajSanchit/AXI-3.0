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
        public string Category { get; set; }
        public bool Disabled { get; set; }

        public Article(string name, double price)
        {
            if (name == null || name == "")
            {
                throw new ArgumentException("Name cannot be empty");
            }
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException("Price cannot be negative");
            }
            Name = name;
            Price = price;
        }
        
        public Article(string name, double price, string barcode, string imgRef, string description, string category, bool disabled)
        {
            if (name == null || name == "")
            {
                throw new ArgumentException("Name cannot be empty");
            }
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException("Price cannot be negative");
            }
            Name = name;
            Price = price;
            Barcode = barcode;
            ImgRef = imgRef;
            Description = description;
            Category = category;
            Disabled = disabled;
        }
        
        public Article(ArticleDto articleDto)
        {
            if(articleDto.Name == null || articleDto.Name == "")
            {
                throw new ArgumentException("Name cannot be empty");
            }
            if(articleDto.Price < 0)
            {
                throw new ArgumentOutOfRangeException("Price cannot be negative");
            }
            Id = articleDto.Id;
            Name = articleDto.Name;
            Barcode = articleDto.Barcode;
            Price = articleDto.Price;
            ImgRef = articleDto.Img;
            Category = articleDto.CategoryName;
            Description = articleDto.Description;
            Disabled = articleDto.Disabled;
        }
        
        public void SetName(string name)
        {
            if(name == null || name == "")
            {
                throw new ArgumentException("Name cannot be empty");
            }
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
            if(price < 0)
            {
                throw new ArgumentOutOfRangeException("Price cannot be negative");
            }
            Price = price;
        }

        public ArticleDto ToDto()
        {
            var dto = new ArticleDto
            {
                Name = Name,
                Id = Id,
                Description = Description,
                Img = ImgRef,
                Price = Price,
                Barcode = Barcode,
                CategoryName = Category,
                Disabled = Disabled
            };
            
            if(Category != null)
            {
                dto.CategoryId = int.Parse(Category);
            }

            return dto;
        }
       
    }
}