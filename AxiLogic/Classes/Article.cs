using AxiInterfaces.DTOs;

namespace AxiLogic.Classes
{ 

    public class Article
    {
        public double Price { get; private set; }
        public string BarCode { get; private set; }
        public string ImgRef { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Id { get; private set; }


        public Article(string name, double price)
        {
            Name = name;
            Price = price;
        }
        
        public Category Category { get; private set; }
        
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
        
        public void  SetBarCode(string barcode)
        {
            BarCode = barcode;
        }
        
        public void SetImg(string img)
        {
            ImgRef = img;
        }
        
        public void SetPrice(double price)
        {
            Price = price;
        }

        public void ToDto()
        {
            var articleDto = new ArticleDto
            {
                Name = Name,
                Id = Id,
                Description = Description,
                ImgRef = ImgRef,
                Price = Price,
                BarCode = BarCode
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