using System.Collections.Generic;
using AxiLogic.Classes;

namespace Axi3._0.Models
{
    public class  ArticleModel
    {
        public double Price { get; set; }
        public string Barcode { get; set; }
        public string ImgRef{ get; set; }
        public string Name{ get; set; }
        public string Description{ get; set; }
        public int Id{ get; set; }
        public string Category{ get; set; }
        public List<string> CategoryEnum { get; set; }
    }
}