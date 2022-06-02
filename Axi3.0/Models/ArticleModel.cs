using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiLogic.Classes;
using AxiLogic.Helpers;

namespace Axi3._0.Models
{
    public class  ArticleModel
    {
        public double Price { get; set; }
        public string Barcode { get; set; }
        public string ImgRef{ get; set; }
        public string Name{ get; set; }
        public string Description{ get; set; }
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public bool Disabled { get; set; }
        public IList<CategoryDto> CategoryEnum { get; set; }
    }
}