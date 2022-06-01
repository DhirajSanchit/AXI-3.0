using System;

namespace AxiDAL.DTOs
{
    public struct ArticleDto
    {
        public double Price;
        public string Barcode;
        public string ImgRef;
        public string Name;
        public string Description;
        public int Id;
        public string CategoryName;
        public int CategoryId;
        public bool Disabled;
    }
}