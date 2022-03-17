namespace AxiLogic.Classes
{ 

    public class Article
    {
        public double Price { get; private set; }
        public string BarCode { get; private set; }
        public string Img { get; private set; }
        public string Name { get; private set; }
        public int Id { get; private set; }


        public Article(string name, double price)
        {
            
        }
        
        public Category Category { get; private set; }
        
        public void SetName(string name)
        {
            Name = name;
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
            Img = img;
        }
        
        public void SetPrice(double price)
        {
            Price = price;
        }
    }

    public enum Category
    {
        Electronics,
        Cosmetics,
        Tools
    }
}