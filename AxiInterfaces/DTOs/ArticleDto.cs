namespace AxiInterfaces.DTOs
{
    public class ArticleDto
    {
        public double Price { get; private set; }
        public string BarCode { get; private set; }
        public string Img { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Id { get; private set; }
    }
}