using AxiDAL.DTOs.Statistics;

namespace AxiLogic.Classes.Statistics
{
    public class AmountInCategory
    {
        public string CategoryName { get; set; }
        public int Amount { get; set; }

        public AmountInCategory()
        {
        }

        public AmountInCategory(AmountInCategoryDto dto)
        {
            CategoryName = dto.CategoryName;
            Amount = dto.Amount;
        }
    }
}