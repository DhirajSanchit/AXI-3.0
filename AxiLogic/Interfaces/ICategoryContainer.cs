using System.Collections.Generic;
using AxiDAL.DTOs;

namespace AxiLogic.Interfaces
{
    public interface ICategoryContainer
    {
        public IList<CategoryDto> GetAllCategories();
        public void AddCategory(CategoryDto categoryDto);
        public void RemoveCategory(CategoryDto categoryDto);
    }
}